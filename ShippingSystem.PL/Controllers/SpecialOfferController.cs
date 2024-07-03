using Microsoft.AspNetCore.Mvc;
using ShippingSystem.BLL.DTOs.SpecialOfferDTOS;
using ShippingSystem.BLL.Services;
using ShippingSystem.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly SpecialOfferService _specialOfferService;

        public SpecialOfferController(SpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialOffer>>> GetAllSpecialOffers()
        {
            var specialOffers = await _specialOfferService.GetAllSpecialOffersAsync();
            return Ok(specialOffers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOffer>> GetSpecialOfferById(int id)
        {
            var specialOffer = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }
            return Ok(specialOffer);
        }

        [HttpPost]
        public async Task<ActionResult<SpecialOffer>> AddSpecialOffer([FromBody] AddSpecialOfferDTO specialOfferDTO)
        {
            if (specialOfferDTO == null)
            {
                return BadRequest("Special offer object is null");
            }

            var addedSpecialOffer = await _specialOfferService.AddSpecialOfferAsync(specialOfferDTO);
            return CreatedAtAction(nameof(GetSpecialOfferById), new { id = addedSpecialOffer.Id }, addedSpecialOffer);
        }

        [HttpGet("Merchant/{merchantId}/SpecialOffers")]
        public async Task<ActionResult<IEnumerable<SpecialOffer>>> GetSpecialOffersByMerchantId(int merchantId)
        {
            var specialOffers = await _specialOfferService.GetSpecialOffersByMerchantIdAsync(merchantId);
            if (specialOffers == null || specialOffers.Count == 0)
            {
                return NotFound();
            }
            return Ok(specialOffers);
        }
    }
}
