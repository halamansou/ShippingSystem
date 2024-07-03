using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.BranchDTOs;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BranchController : ControllerBase
	{
		private readonly BranchService branchService;

		public BranchController(BranchService branchService)
		{
			this.branchService = branchService;
		}

		[HttpGet]
		public async Task<IActionResult> GetBranches()
		{
			var branches = await branchService.GetBranches();
			return Ok(branches);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBranchByID(int id)
		{
			var branch = await branchService.GetBranchByID(id);
			if (branch != null)
			{
				return Ok(branch);
			}
			else
				return NotFound();
		}

		[HttpGet("changeStatus/{id}")]   
		public async Task<IActionResult> ChangeStatus(int id)
		{
			return Ok(await branchService.ChangeStatus(id));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBranch(int id)
		{
			return Ok(await branchService.DeleteBranch(id));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBranch(int id,CreateBranchDTO branchdto)
		{
			var branch = await branchService.UpdateBranch(id, branchdto);
			if (branch != null)
			{
				return Ok(branch);
			}
			else
				return NotFound();

		}
		[HttpPost]
		public async Task<IActionResult> AddBranch(CreateBranchDTO branchdto)
		{
			return Ok(await branchService.AddBranch(branchdto));
		}
		[HttpPost("pagination")]
		public async Task<IActionResult> BranchPagination(int page, int pageSize)
		{
			return Ok(branchService.BranchPagination(page, pageSize));
		}

	}
}
