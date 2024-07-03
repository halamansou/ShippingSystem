using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		public LoginService LoginService { get; }
        public LoginController(LoginService loginService)
        {
			LoginService = loginService;
		}

		[HttpPost]
		public async Task<IActionResult> Login(string email, string password)
		{
			//var login = LoginService.Login(email, password);
			return Ok();
		}
	}
}
