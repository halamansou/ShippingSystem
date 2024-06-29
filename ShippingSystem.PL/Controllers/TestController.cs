using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IGenericRepository<Account> repository;

        public TestController(IGenericRepository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IQueryable<Account>> Get()
        {
            return await repository.GetAllWithFilter(obj => obj.IsDeleted == false && obj.Name == "Ahmed");
        }
    }
}
