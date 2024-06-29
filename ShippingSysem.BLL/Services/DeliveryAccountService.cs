using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSysem.BLL.DTOs.DeliveryDTOS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class DeliveryAccountService
    {
        private readonly IGenericRepository<DeliveryAccount> genRepo;

        public DeliveryAccountService(IGenericRepository<DeliveryAccount> genRepo)
        {
            this.genRepo = genRepo;
        }

        public async Task<List<DisplayDeliveryAccountsDTO>> GetAllDeliveryAccounts()
        {
            var accounts = await genRepo.GetAllAsync();
            var dtos = accounts
                .Select(acc => new DisplayDeliveryAccountsDTO
                {
                    UserName = acc.UserName,
                    Email = acc.Email,
                    Phone = acc.PhoneNumber,
                    Branch = acc.Branch.Name , // Ensure Branch.Name is safely accessed
                    Status = acc.Status,
                    IsDeleted = acc.IsDeleted,
                    DiscountType = acc.Discount_type
                })
                .ToList();

            return dtos;
        }
    }
}
