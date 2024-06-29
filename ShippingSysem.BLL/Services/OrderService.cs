using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class OrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        //Mpping The Orders return from The Database without Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(status);

            var ordersDtos = await MappingorderDTOs(orders);

            return await Task.FromResult(ordersDtos);
        }

        //Mpping The Orders return from The Database with Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(int page, int pageSize, string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(page,pageSize,status);

            var ordersDtos = await MappingorderDTOs(orders);

            return await Task.FromResult(ordersDtos);
        }


        //Private Method using for Mapping The orders return from database(order Repository)
        private async Task<List<OrederReadDTO>> MappingorderDTOs(IQueryable<Order> orders)
        {
            return await orders.Select(o => new OrederReadDTO
            {
                Id = o.Id,
                IsDeleted = o.IsDeleted,
                ClientName = o.ClientName,
                Status = o.Status,
                TotalPrice = o.TotalPrice,
                TotalWeight = o.TotalWeight,
                ReceivedMoney = o.ReceivedMoney,
                DeliveryPrice = o.DeliveryPrice,
                PaiedMoney = o.PaiedMoney,
                Government = o.government.Name,
                Cityt = o.city.Name,
                PhoneOne = o.PhoneOne,
                PhoneTwo = o.PhoneTwo,
                Email = o.Email,
                Notes = o.Notes,
                StreetAndVillage = o.StreetAndVillage,
                StaffMemberName = o.StaffMemberAccount.Name,
                MerchantName = o.MerchantAccount.Name,
                DeliveryName = o.DeliveryAccount.Name,
                CreatedDate = o.CreatedDate,
                DeliverydDate = o.DeliverydDate,
            }).ToListAsync();
        }
    }
}
