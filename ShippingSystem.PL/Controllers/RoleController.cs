using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet("GetRole/{id}")]

        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await service.GetRole(id);
            return Ok(new
            {
                success = true,

                roleId = role.Id,
                roleName = role.Name,
            });
        }

        [HttpPost("AddRole/{rolename}")]
        public async Task<IActionResult> AddRole(string rolename)
        {
            var result = await service.AddRole(rolename);
            var respone = new { Result = result.Name, ID = result.Id };
            if (result != null) return Ok(respone);

            return NotFound();
        }


        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] string rolename)
        {
            var result = await service.UpdateRole(id, rolename);
            if (result != null)
            {
                return Ok(new { Result = result.Name, ID = result.Id });
            }
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



        [HttpPut("UpdateRolePermissions/{id}")]
        public async Task<IActionResult> UpdateRolePermissions(int id, [FromBody] List<PermissionDTO> permissions)
        {
            var result = await service.UpdateRolePermissionsForUser(id, permissions);

            if (result != null) return Ok(new { state = "Updated", restult = result });

            return Ok(new { state = "failed" });
        }


        [HttpDelete("DeleteRole/{id}")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await service.DeleteRole(id);


            if (result.IsDeleted == true) return Ok(new
            {
                success = true,

                roleId = result.Id
            });
            else return NotFound();
        }





    }
}
