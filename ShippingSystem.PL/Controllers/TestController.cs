using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IGenericRepository<Account> repository;
        private readonly OrderService orderService;

        public TestController(IGenericRepository<Account> repository,OrderService orderService)
        {
            this.repository = repository;
            this.orderService = orderService;
        }

        //[HttpGet]
        //public async Task<IQueryable<Account>> Get()
        //{
        //    return await repository.GetAllWithFilter(obj => obj.IsDeleted == false && obj.Name == "Ahmed");
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var q = await orderService.GetAllFilterdOrders();

            var q2 = q.GroupBy(o=> o.Status).Select(o=> new {Status = o.Key ,Count =  o.Count()});

            return Ok(q2);
        }
      
    }
}
