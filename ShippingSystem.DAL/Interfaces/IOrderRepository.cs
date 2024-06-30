using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<Order> AddAsync(Order entity);                      
        public Task<Order> DeleteById(int id);
        public Task<IQueryable<Order>> GetAllAsync();
        public Task<IQueryable<Order>> GetAllAsyncWithPagination(int page = 1, int pageSize = 10);
        public Task<IQueryable<Order>> GetAllWithFilter(Expression<Func<Order, bool>> expression);
        public Task<Order> GetByIdAsync(int id);
        public Task<int> SaveAsync();
        public Task<Order> Update(Order entity);
        public Task<IQueryable<Order>> GetAllFilterdOrdersAsync(int page,int pageSize, string Status = "");
        public Task<IQueryable<Order>> GetAllFilterdOrdersAsync(string Status = "");
        public  Task<IQueryable<OrderCount>> GetOrderCountsAsync();
        public  Task<IQueryable<OrderCount>> GetOrderCountsAsync(int merchantId);
    }
}
