using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.BranchDTOs;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
	public class BranchService
	{
		private readonly IGenericStatusRepository<Branch> iGenericStatusRepository;
		private readonly IGenericStatusRepository<Government> iGenericStatusRepositoryGovernment;
		public BranchService(IGenericStatusRepository<Branch> iGenericStatusRepository, IGenericStatusRepository<Government> iGenericStatusRepositoryGovernment) {
			this.iGenericStatusRepository = iGenericStatusRepository;
			this.iGenericStatusRepositoryGovernment = iGenericStatusRepositoryGovernment;
		}

		public async Task<ReadBranchDTO> GetBranchByID(int id)
		{
			var branch = await iGenericStatusRepository.GetByIdAsync(id);
			if (branch != null)
			{
				return MappingBranchToReadBranchDTO(branch);
			}
			else
				return null;
		}
		public async Task<List<ReadBranchDTO>> GetBranches()
		{
			var branches = await iGenericStatusRepository.GetAllAsync();
			if (branches != null)
			{
				var dtos = await branches
				.Select(branch => new ReadBranchDTO
				{
					Id = branch.Id,
					Name = branch.Name,
					CreatedDate = branch.CreatedDate,
					GovernmentID = branch.GovernmentID,
					GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(branch.GovernmentID).Result.Name,
					IsDeleted = branch.IsDeleted,
					Status = branch.Status
				}).ToListAsync();

				return dtos;
			}
			else
				return null;
		}

		public async Task<ReadBranchDTO> UpdateBranch(int id, CreateBranchDTO branchdto)
		{
			var branch = await iGenericStatusRepository.GetByIdAsync(id);

			if (branch != null)
			{
				//mapping from CreateBranchDTO to Branch
				branch.Name = branchdto.Name;
				branch.GovernmentID = branchdto.GovernmentID;

				Branch updatedBranch = iGenericStatusRepository.Update(branch).Result;
				await iGenericStatusRepository.SaveAsync();

				//mapping from Branch to ReadBranchDTO
				return MappingBranchToReadBranchDTO(branch);
			}
			else
				return null;
		}

		public async Task<ReadBranchDTO> AddBranch(CreateBranchDTO branchdto)
		{
			Branch branch = new()
			{
				//mapping from CreateBranchDTO to Branch
				Name = branchdto.Name,
				GovernmentID = branchdto.GovernmentID,
				Status = branchdto.Status
			};

			Branch addedBranch = iGenericStatusRepository.AddAsync(branch).Result;
			await iGenericStatusRepository.SaveAsync();

			//mapping from Branch to ReadBranchDTO
			return MappingBranchToReadBranchDTO(branch);
		}
		public async Task<bool> DeleteBranch(int id)
		{
			var row = await iGenericStatusRepository.GetByIdAsync(id);
			var deletedOrNot = false;
			if (row != null)
			{
				iGenericStatusRepository.Delete(row);
				await iGenericStatusRepository.SaveAsync();
				deletedOrNot = true;
			}
			return deletedOrNot;
		}
		public async Task<bool> ChangeStatus(int id)
		{
			var row = await iGenericStatusRepository.GetByIdAsync(id);
			var changedOrNot = false;
			if (row != null)
			{
				iGenericStatusRepository.ChangeStatus(row);
				await iGenericStatusRepository.SaveAsync();
				changedOrNot = true;
			}
			return changedOrNot;
		}
		public List<ReadBranchDTO> BranchPagination(int page, int pageSize)
		{
			return iGenericStatusRepository.GetAllAsyncWithPagination(page,pageSize).Result.ToList()
				   .Select(b => MappingBranchToReadBranchDTO(b)).ToList();
		}

		public ReadBranchDTO MappingBranchToReadBranchDTO(Branch branch)
		{
			return new ReadBranchDTO
			{
				Id = branch.Id,
				Name = branch.Name,
				CreatedDate = branch.CreatedDate,
				GovernmentID = branch.GovernmentID,
				GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(branch.GovernmentID).Result.Name,
				IsDeleted = branch.IsDeleted,
				Status = branch.Status
			};
		}
	}
}
