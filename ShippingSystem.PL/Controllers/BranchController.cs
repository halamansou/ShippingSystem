using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("changeStatus/{id}")]   
		public async Task<IActionResult> ChangeStatus(int id)
		{
			return Ok(await branchService.ChangeStatus(id));
		}
		
	}
}
