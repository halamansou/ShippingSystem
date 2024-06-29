using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using ShippingSysem.BLL.DTOs.PermissionsDTOS;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly PermissionsService service;
        private readonly ShippingDBContext dBContext;

        public PermissionsController(PermissionsService service, ShippingDBContext dBContext)
        {
            this.service = service;
            this.dBContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountPermissions(int id = 2)
        {


            var account = await service.GetAllPermissionsForUser(id);
            if (account != null)
            {

                return Ok(account);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccountPermissions(int id, List<PermissionDTO> permissions)
        {
            var result = await service.UpdatePermissionsForUser(id, permissions);
            if (result) return Ok("Updated");
            else return NotFound();
        }


    }
}
