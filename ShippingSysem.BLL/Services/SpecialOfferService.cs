using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;

namespace ShippingSystem.BLL.Services
{
    public class SpecialOfferService
    {
        private readonly GenericRepository<SpecialOffer> _specialOfferRepository;

        public SpecialOfferService(GenericRepository<SpecialOffer> specialOfferRepository)
        {
            _specialOfferRepository = specialOfferRepository;
        }

        public async Task<IList<SpecialOffer>> GetAllSpecialOffersAsync()
        {
            var specialOffers = await _specialOfferRepository.GetAllAsync();
            return specialOffers.ToList();
        }
    }
}
