using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories
{
    public class CityReposatry: GenericRepository<City> {
        private readonly ShippingDBContext context;
        private readonly DbSet<City> cities;
        public CityReposatry(ShippingDBContext context) : base(context)
        {
            this.context = context;
            cities = this.context.Cities;
        }
        
    
    }
}
