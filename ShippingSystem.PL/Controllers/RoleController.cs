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
    public class RoleController : ControllerBase
    {
        private readonly RoleService service;
        private readonly ShippingDBContext dBContext;

        public RoleController(RoleService service, ShippingDBContext dBContext)
        {
            this.service = service;
            this.dBContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }





        [Route("AllRoles")]
        [HttpGet]

        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await service.GetAllRoles();
            return Ok(roles);
        }
        [Route("AddRole")]

        [HttpPost]
        public async Task<IActionResult> AddRole(string rolename)
        {
            var result = await service.AddRole(rolename);
            if (result != null) return Ok($"Created Role with Name : {result.Name} and ID : {result.Id}");

            return NotFound();
        }
        [Route("UpdateRole")]

        [HttpPut]
        public async Task<IActionResult> UpdateRole(int id, string rolename)
        {
            var result = await service.UpdateRole(id, rolename);
            if (result != null) return Ok($"Updated Role with Name : {result.Name} and ID : {result.Id}");

            return NotFound();
        }



        [HttpGet("GetRolePermissions/{id}")]
        public async Task<IActionResult> GetRolePermissions(int id)
        {


            var account = await service.GetAllRolePermissionsForUser(id);
            if (account != null)
            {

                return Ok(account);
            }

            return NotFound();
        }

        [Route("UpdateRolePermissions")]

        [HttpPut]
        public async Task<IActionResult> UpdateRolePermissions(int id, List<PermissionDTO> permissions)
        {
            var result = await service.UpdateRolePermissionsForUser(id, permissions);
            if (result) return Ok("Updated");
            else return NotFound();
        }


        [HttpDelete("DeleteRole/{id}")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await service.DeleteRole(id);
            if (result) return Ok("Deleted");
            else return NotFound();
        }





    }
}
