using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;



namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Account> genRepo;
        private readonly EmployeeService empService;

        public EmployeesController(IGenericRepository<Account> genRepo, EmployeeService EmpService)
        {
            this.genRepo = genRepo;
            empService = EmpService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var account = await empService.GetAllEmps();
            return Ok(account);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpByID(int id)
        {
            try
            {
                var employee = await empService.GetEmpById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("UpdateEmpStatus/{id}")]
        public async Task<IActionResult> UpdateEmpStatus(int id)
        {
            var account = await empService.UpdateEmpStatus(id);
            return Ok(account);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddEmp(CreateEmployeeDTO EmpDto)
        {
            var account = await empService.AddEmp(EmpDto);
            return Ok(account);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateEmp(int id, CreateEmployeeDTO EmpDto)
        {
            var acc = await empService.UpdateEmp(id, EmpDto);
            //var account = empService.GetEmpById(id);
            return Ok(acc);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var acc = await empService.DeleteEmpByID(id);

            return Ok(acc);
        }
    }
}
