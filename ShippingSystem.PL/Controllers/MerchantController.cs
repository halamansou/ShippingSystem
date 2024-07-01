using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.MerchantDTOS;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {

        private readonly MerchantAccountService _merchantAccountService;

        public MerchantController(MerchantAccountService _merchantAccountService)
        {
            this._merchantAccountService = _merchantAccountService;
        }


        //Action to display Merchant Accounts
        [HttpGet]
        public async Task<IActionResult> GetAllMerchantAccounts()
        {
            var accounts = await _merchantAccountService.GetAllMerchantAccounts();
            return Ok(accounts);
        }



        // Action to add Merchant Account
        [HttpPost]
        public async Task<IActionResult> AddMerchantAccount([FromBody] AddMerchantAccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _merchantAccountService.AddMerchantAccount(dto);
            if (success)
            {
                return Ok("Merchant account added successfully.");
            }

            return BadRequest("Could not add merchant account.");
        }




        // Action to delete merchant account
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteMerchantAccount(int accountId)
        {
            var success = await _merchantAccountService.DeleteMerchantAccount(accountId);
            if (success)
            {
                return Ok("Merchant account deleted successfully.");
            }

            return NotFound("Merchant account not found.");
        }

        // Action to get merchant account by ID
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetMerchantAccountById(int accountId)
        {
            var account = await _merchantAccountService.GetMerchantAccountById(accountId);
            if (account != null)
            {
                return Ok(account);
            }

            return NotFound("Merchant account not found.");
        }

        // Action to update merchant account
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateMerchantAccount(int accountId, [FromBody] AddMerchantAccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _merchantAccountService.UpdateMerchantAccount(accountId, dto);
            if (success)
            {
                return Ok("Merchant account updated successfully.");
            }

            return NotFound("Merchant account not found.");
        }

    }
}
