using Azure;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ShippingDBContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ShippingDBContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }
        public Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public async Task<T> DeleteById(int id)
        {
            T entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
            await context.SaveChangesAsync();

            return await Task.FromResult(entity);
        }
        public async Task<T> Update(T entity)
        {
            dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.Where(obj => obj.IsDeleted == false).AsNoTracking());
        }
        public async Task<IQueryable<T>> GetAllAsyncWithPagination(int page = 1,int pageSize = 10)
        {
            return await Task.FromResult(dbSet.Where(obj => obj.IsDeleted == false)
                                              .Skip((page-1) * pageSize)
                                              .Take(pageSize)
                                              .AsNoTracking());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(dbSet.FirstOrDefault(obj => obj.Id == id && obj.IsDeleted == false));
        }

        public async Task<int> SaveAsync()
        {
            var rowsEffected = await context.SaveChangesAsync();
            return await Task.FromResult(rowsEffected);
        }
        
        public async Task<IQueryable<T>> GetAllWithFilter(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(dbSet.Where(expression).AsNoTracking());
        }

    }
}
