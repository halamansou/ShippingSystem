using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.DTOs.ProductDTOs;
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

            return await MappingorderDTOs(orders);
        }

        //Mpping The Orders return from The Database with Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(int page, int pageSize, string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(page, pageSize, status);

            return await MappingorderDTOs(orders);
        }

        //Get Count For all orders depending on Status 
        public async Task<List<OrderCount>> GetOrderCountsAsync()
        {
            var Orders = await repository.GetOrderCountsAsync();
            return await Orders.ToListAsync();
        }

        //Get Count For all orders for specific mrechant account depending on Status 
        public async Task<List<OrderCount>> GetOrderCountsAsync(int merchantId)
        {
            var Orders = await repository.GetOrderCountsAsync(merchantId);
            return await Orders.ToListAsync();
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
        private async Task<OrederReadDTO> MappingorderToOrderReadDTO(Order order)
        {

            return new OrederReadDTO()
            {
                Id = order.Id,
                IsDeleted = order.IsDeleted,
                ClientName = order.ClientName,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                ReceivedMoney = order.ReceivedMoney,
                DeliveryPrice = order.DeliveryPrice,
                PaiedMoney = order.PaiedMoney,
                Government = order.government.Name,
                Cityt = order.city.Name,
                PhoneOne = order.PhoneOne,
                PhoneTwo = order.PhoneTwo,
                Email = order.Email,
                Notes = order.Notes,
                StreetAndVillage = order.StreetAndVillage,
                StaffMemberName = order.StaffMemberAccount.Name,
                MerchantName = order.MerchantAccount.Name,
                DeliveryName = order.DeliveryAccount.Name,
                CreatedDate = order.CreatedDate,
                DeliverydDate = order.DeliverydDate,
                TotalWeight = order.TotalWeight
            };
        }


        // Mapping the Orders from Dto To Database 
        public async Task<OrderCreateDTO> CreateOrder(OrderCreateDTO _orderCreateDto)
        {

            Order order = new Order()
            {
                CitytId = _orderCreateDto.CityID,
                ClientName = _orderCreateDto.ClientName,
                Email = _orderCreateDto.Email,
                Notes = _orderCreateDto.Notes,
                MerchantID = _orderCreateDto.MerchantID,
                PaymentTypeID = _orderCreateDto.PaymentTypeID,
                ShippingTypeID = _orderCreateDto.ShippingTypeID,
                PhoneOne = _orderCreateDto.PhoneOne,
                PhoneTwo = _orderCreateDto.PhoneTwo,
                Status = _orderCreateDto.Status,
                GovernmentId = _orderCreateDto.GovernmentId,
                StreetAndVillage = _orderCreateDto.StreetAndVillage,
                TotalWeight = _orderCreateDto.TotalWeight,
                TotalPrice = _orderCreateDto.TotalPrice,
                Products = _orderCreateDto.Products.Select(p => new Product()
                {
                    Quantity = p.Quantity,
                    Weight = p.Weight,
                    Price = p.Price,
                    Name = p.Name,

                }).ToList(),
            };
            await repository.AddAsync(order);
            await repository.SaveAsync();

            return _orderCreateDto;


        }


    }
}
