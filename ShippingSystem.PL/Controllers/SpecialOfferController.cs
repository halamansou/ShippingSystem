using Microsoft.AspNetCore.Mvc;
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
    }
}
