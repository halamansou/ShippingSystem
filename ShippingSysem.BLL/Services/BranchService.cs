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
		public BranchService(IGenericStatusRepository<Branch> iGenericStatusRepository) {
			this.iGenericStatusRepository = iGenericStatusRepository;
		}

		public async Task<List<ReadBranchDTO>> GetBranches()
		{
			var branches = await iGenericStatusRepository.GetAllAsync();
			if (branches != null)
			{
				var dtos = await branches
				.Select(b =>
				new ReadBranchDTO
				{
					Id = b.Id,
					Name = b.Name,
					CreatedDate = b.CreatedDate,
					Status = b.Status
				}).ToListAsync();

				return dtos;
			}
			else
				return null;
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

	}
}
