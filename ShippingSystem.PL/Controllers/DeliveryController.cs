using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;
using ShippingSysem.BLL.DTOs.DeliveryDTOS; 

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase 
    {
        private readonly DeliveryAccountService deliveryAccountService;

        public DeliveryController(DeliveryAccountService deliveryAccountService) // Corrected the constructor name
        {
            this.deliveryAccountService = deliveryAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveryAccounts()
        {
            var accounts = await deliveryAccountService.GetAllDeliveryAccounts();
            return Ok(accounts);
        }
    }
}
