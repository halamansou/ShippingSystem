using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string status = "") {
            var orders = await orderService.GetAllFilterdOrders(status);

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("AllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination(int page = 1,int pageSize = 10,string status="")
        {
            var orders = await orderService.GetAllFilterdOrders(page,pageSize,status);
            
            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("OrdersCount")]
        public async Task<IActionResult> GetOrdersCount(int merchantId = 0)
        {
            if(merchantId == 0)
            {
                var orderCounts = await orderService.GetOrderCountsAsync();
                
                if (!orderCounts.Any())
                    return NotFound();

                return Ok(orderCounts);
            }
            else
            {
                var orderCounts = await orderService.GetOrderCountsAsync(merchantId);

                if (!orderCounts.Any())
                    return NotFound();

                return Ok(orderCounts);
            }
                
        }
    }
}
