using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSysem.BLL.DTOs.DeliveryDTOS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ShippingSysem.BLL.Services
{
    public class DeliveryAccountService
    {
        private readonly IGenericRepository<DeliveryAccount> genRepo;
        private readonly ILogger<DeliveryAccountService> _logger;

        public DeliveryAccountService(IGenericRepository<DeliveryAccount> genRepo, ILogger<DeliveryAccountService> logger)
        {
            this.genRepo = genRepo;
            _logger = logger;
        }


        //method to Display All Delivery Accounts
        public async Task<List<DisplayDeliveryAccountsDTO>> GetAllDeliveryAccounts()
        {
            var accounts = await genRepo.GetAllAsync();
            var dtos = accounts
                .Select(acc => new DisplayDeliveryAccountsDTO
                {
                    id= acc.Id,
                    UserName = acc.UserName,
                    Email = acc.Email,
                    Phone = acc.PhoneNumber,
                    Branch = acc.Branch.Name,
                    Status = acc.Status,
                    IsDeleted = acc.IsDeleted,
                    DiscountType = acc.Discount_type
                })
                .ToList();

            return dtos;
        }
        //method to  Add Delivery Account



        public async Task<bool> AddDeliveryAccount(AddDeliveryAccountDTO dto)
        {
            try
            {
                var account = new DeliveryAccount
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PasswordHash = dto.Password,
                    Governments = dto.Governments,
                    BranchID = dto.Branch,
                    PhoneNumber = dto.Phone,
                    Address = dto.Address,
                    Discount_type = dto.Discount_type,
                    Company_Percantage = dto.Company_Percantage,
                };

                await genRepo.AddAsync(account);
                await genRepo.SaveAsync(); 
                return true;
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Error adding delivery account");
                return false;
            }
        }




        // Method to Delete Delivery Account
        public async Task<bool> DeleteDeliveryAccount(int accountId)
        {
            try
            {
                var account = await genRepo.GetByIdAsync(accountId);
                if (account == null)
                {
                    _logger.LogWarning($"Delivery account with ID {accountId} not found.");
                    return false;
                }

                await genRepo.DeleteById(accountId);
                await genRepo.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting delivery account with ID {accountId}");
                return false;
            }
        }


        // Method to get Delivery Account

        public async Task<DeliveryAccount> GetDeliveryAccountById(int id)
        {
            return await genRepo.GetByIdAsync(id);
        }

        // Method to update Delivery Account

        public async Task<bool> UpdateDeliveryAccount(int accountId, AddDeliveryAccountDTO dto)
        {
            try
            {
                var existingAccount = await genRepo.GetByIdAsync(accountId);
                if (existingAccount == null)
                {
                    _logger.LogWarning($"Delivery account with ID {accountId} not found.");
                    return false;
                }

                // Update properties
                existingAccount.UserName = dto.UserName;
                existingAccount.Email = dto.Email;
                existingAccount.PasswordHash = dto.Password;
                existingAccount.Governments = dto.Governments;
                existingAccount.BranchID = dto.Branch;
                existingAccount.PhoneNumber = dto.Phone;
                existingAccount.Address = dto.Address;
                existingAccount.Discount_type = dto.Discount_type;
                existingAccount.Company_Percantage = dto.Company_Percantage;

                await genRepo.Update(existingAccount);
                await genRepo.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating delivery account with ID {accountId}");
                return false;
            }
        }



    }
}