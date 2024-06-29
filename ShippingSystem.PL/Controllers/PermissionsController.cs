using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly PermissionsService service;

        public PermissionsController(PermissionsService service)
        {
            this.service = service;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var permissions = service.GetAllPermissionsForUser();
            return Ok(permissions);
        }


    }
}
