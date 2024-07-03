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
    public class CityReposatry: GenericStatusRepository<City>,ICityReposatry{
    //public class CityReposatry: GenericRepository<City> ,ICityReposatry{

        private readonly ShippingDBContext context;
        //private readonly DbSet<City> cities;
        public CityReposatry(ShippingDBContext context) : base(context)
        {
            this.context = context;
            //cities = this.context.Set<City>();
        }

        //Get All Orders Without Pagination Using Status As Filteration
        //Give Status default value and chek it if I want to return All orders without filteration
        public async Task<IQueryable<City>> GetAllFilterdCitiesAsync(bool status = true)
        {
            if (status)
                return await Task.FromResult(
                                            GetCities(order => order.IsDeleted == false)
                                            );


            return await Task.FromResult(
                                        GetCities(order => order.IsDeleted == false && order.Status == status)
                                        );
        }

        //Get All Orders With Pagination Using Status As Filteration
        //Give Status default value and chek it if I want to return All orders without filteration
        public async Task<IQueryable<City>> GetAllFilterdCitiesAsync(int page, int pageSize, bool Status = true)
        {
            if (Status)
                return await Task.FromResult(
                                            GetCities(order => order.IsDeleted == false)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            );


            return await Task.FromResult(
                                        GetCities(order => order.IsDeleted == false && order.Status == Status)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        );
        }

        //Method to get ALl Navigation Properities I Needed
        //private method to get all navigation properties I need
        private IQueryable<City> GetCities(Expression<Func<City, bool>> expression)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            return context.Cities.Include(city => city.Government)
                                 .Where(expression)
                                 .AsNoTracking();
        }
        public async Task< City> GetCity(Expression<Func<City, bool>> expression)
        {
            if (context == null)
                throw new InvalidOperationException("Context is null");

            if (context.Cities == null)
                throw new InvalidOperationException("Cities DbSet is null");

            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            return  context.Cities.Include(city => city.Government)
                                 .Where(expression).FirstOrDefault();
        }


    }
}
