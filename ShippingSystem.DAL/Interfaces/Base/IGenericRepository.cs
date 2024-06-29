using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Interfaces.Base
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> DeleteById(int id);
        Task<int> SaveAsync();
        Task<IQueryable<T>> GetAllWithFilter(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsyncWithPagination(int page = 1, int pageSize = 10);
    }
}
