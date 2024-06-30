using ShippingSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class CityService
    {
        private CityReposatry _cityReposatry;
        public CityService(CityReposatry cityReposatry) {

           this._cityReposatry = cityReposatry;
        }
    }
}
