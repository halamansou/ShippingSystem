using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public  OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderCreateDTO orderCreateDto)
        {
            var order = await orderService.CreateOrder(orderCreateDto);
            return Ok(order);
        }
    }
}
