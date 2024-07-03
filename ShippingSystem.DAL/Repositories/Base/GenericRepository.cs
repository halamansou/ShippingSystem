using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteById(int id)
        {
            T entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteFullEntityById(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return dbSet.Where(obj => !obj.IsDeleted).AsNoTracking();
        }

        public async Task<IQueryable<T>> GetAllAsyncWithPagination(int page = 1, int pageSize = 10)
        {
            return dbSet.Where(obj => !obj.IsDeleted)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(obj => obj.Id == id && !obj.IsDeleted);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllWithFilter(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).AsNoTracking();
        }
    }
}
