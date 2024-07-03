using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.GovernmentDTOs;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GovernmentController : ControllerBase
	{
		private readonly GovernmentService governmentService;

		public GovernmentController(GovernmentService governmentService)
		{
			this.governmentService = governmentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllGovernments()
		{
			var governments = await governmentService.GetGovernments();
			return Ok(governments);
		}
		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetGovernmentByID(int id)
		{
			var government = await governmentService.GetGovernmentByID(id);
			if (government != null)
			{
				return Ok(government);
			}
			else
				return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateGovernment(int id, CreateGovernmentDTO governmentdto)
		{
			var government = await governmentService.UpdateGovernment(id, governmentdto);
			if (government != null)
			{
				return Ok(government);
			}
			else
				return NotFound();

		}
		
		[HttpPost]
		public async Task<IActionResult> AddGovernment(CreateGovernmentDTO governmentdto)
		{
			return Ok(await governmentService.AddGovernment(governmentdto));
		}
		
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGovernment(int id)
		{
			return Ok(await governmentService.DeleteGovernment(id));
		}
		
		[HttpGet("changeStatus/{id}")]
		public async Task<IActionResult> ChangeStatus(int id)
		{
			return Ok(await governmentService.ChangeStatus(id));
		}

		[HttpPost("pagination")]
		public async Task<IActionResult> GovernmentPagination(int page, int pageSize)
		{
			return Ok(governmentService.GovernmentPagination(page, pageSize));
		}

	}
}
