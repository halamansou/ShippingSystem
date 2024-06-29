using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ShippingDBContext context;
        private readonly DbSet<Order> orders;
        public OrderRepository(ShippingDBContext context):base(context)
        {
            this.context = context;
            orders = this.context.Orders;
        }

        //Get All Orders Without Pagination Using Status As Filteration
        //Give Status default value and chek it if I want to return All orders without filteration
        public async Task<IQueryable<Order>> GetAllFilterdOrdersAsync(string status = "")
        {
            if (string.IsNullOrEmpty(status))
                return await Task.FromResult(GetOrders(order=> order.IsDeleted == false));


            return await Task.FromResult(GetOrders(order=> order.IsDeleted == false && order.Status == status));
        }

        //Get All Orders With Pagination Using Status As Filteration
        //Give Status default value and chek it if I want to return All orders without filteration
        public async Task<IQueryable<Order>> GetAllFilterdOrdersAsync(int page, int pageSize, string Status = "")
        {
            if (string.IsNullOrEmpty(Status))
                return await Task.FromResult(GetOrders(order=>order.IsDeleted == false).Skip((page - 1) * pageSize)
                                                                                       .Take(pageSize));

            return await Task.FromResult(GetOrders(order => order.IsDeleted == false && order.Status == Status).Skip((page - 1) * pageSize)
                                                                                       .Take(pageSize));
        }

        //private method to get all navigation properties I need
        private IQueryable<Order> GetOrders(Expression<Func<Order, bool>> expression)
        {
            return orders.Where(expression)
                         .Include(order => order.city)
                         .Include(order => order.government)
                         .Include(order => order.MerchantAccount)
                         .Include(order => order.StaffMemberAccount)
                         .Include(order => order.DeliveryAccount)
                         .AsNoTracking();
        }
    }
}
