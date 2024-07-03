using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.BranchDTOs;
using ShippingSysem.BLL.DTOs.CityDTOS;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories;
using ShippingSystem.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class CityService
    {
        private readonly CityReposatry _cityReposatry;
        private readonly IGenericStatusRepository<Government> _genericRepository;
        //private readonly IGenericRepository<City> genericCityRepository;

        public CityService(CityReposatry cityReposatry, IGenericStatusRepository<Government> genericRepository)
        {
            _cityReposatry = cityReposatry;
            _genericRepository = genericRepository;
            //this.genericCityRepository = genericCityRepository;
        }

        public async Task<CityReadDTO> AddCity(CityCreateDTO cityDto)
        {
            City city = new City
            {
                Name = cityDto.Name,
                NormalShippingCost = cityDto.NormalShippingCost,
                PickupShippingCost = cityDto.PickupShippingCost,
                GovernmentID = cityDto.GovernmentID,
            };

            await _cityReposatry.AddAsync(city);
            await _cityReposatry.SaveAsync();

            var government = await _genericRepository.GetByIdAsync(cityDto.GovernmentID);

            return new CityReadDTO()
            {
                Id=city.Id,
                GovernmentID = government.Id,
                GovernmentName = government.Name,
                NormalShippingCost = cityDto.NormalShippingCost,
                PickupShippingCost = cityDto.PickupShippingCost,
                Name = cityDto.Name,
                Status = cityDto.Status
            };
        }
        public async Task<List<CityReadDTO>> getAllCities() { 
        
        var cities = await _cityReposatry.GetAllAsync();
            return await cities.Select(x =>
               new CityReadDTO()
               {
                   Id = x.Id,
                   GovernmentID = x.GovernmentID,
                   GovernmentName = x.Government.Name,
                   NormalShippingCost = x.NormalShippingCost,
                   PickupShippingCost = x.PickupShippingCost,
                   Name = x.Name,
                   Status = x.Status

               }).ToListAsync();

        }
        //using function from reposatry
        //erro null at cities
        //public async Task<List<CityReadDTO>> GetCitiesWithGovernments(int governmentID)
        //{
        //  IQueryable<City> cities=  _cityReposatry.GetCites(x => x.GovernmentID == governmentID );
        //    return await cities.Select(x =>
        //         new CityReadDTO()
        //         {
        //             GovernmentID = governmentID,
        //             GovernmentName = x.Government.Name,
        //             NormalShippingCost = x.NormalShippingCost,
        //             PickupShippingCost = x.PickupShippingCost,
        //             Name = x.Name,
        //             Status = x.Status
        //         }).ToListAsync();
        //}

        //Here Iwant to  get all cities with navigation property 
        //using function from genric reposatry
        public async Task<List<CityReadDTO>> GetCitiesWithGovernment(int governmentID) {
         var CitiesList = await _cityReposatry.GetAllWithFilter(x => x.GovernmentID == governmentID && x.IsDeleted == false);
            return await CitiesList.Select(x =>
                new CityReadDTO()
                {
                    GovernmentID = governmentID,
                    GovernmentName = x.Government.Name,
                    NormalShippingCost = x.NormalShippingCost,
                    PickupShippingCost = x.PickupShippingCost,
                    Name = x.Name,
                    Status = x.Status

                }).ToListAsync();
        }

        public async Task<bool> changeStatus(int id) {
         City city = await  _cityReposatry.GetByIdAsync(id);
            bool changeOrNot = false;
            if(city != null)
            {
            _cityReposatry.ChangeStatus(city);
            _cityReposatry.SaveAsync();
                
                changeOrNot = true;
            }
            return changeOrNot;

        }
        public async Task<bool> Delete(int id) {
         City city = await  _cityReposatry.GetByIdAsync(id);
            bool changeOrNot = false;
            if(city != null)
            {
            _cityReposatry.Delete(city);
            _cityReposatry.SaveAsync();
                
                changeOrNot = true;
            }
            return changeOrNot;

        }
        public async Task<CityReadDTO> UpdateCity(int id, CityCreateDTO CityCreateDTO)
        {
            //1- get city by id 
            var city = await _cityReposatry.GetByIdAsync(id);

            //2- map data in cityCreateDTO TO City
            city.Name = CityCreateDTO.Name;
            city.Status = CityCreateDTO.Status;
            city.PickupShippingCost= CityCreateDTO.PickupShippingCost;
            city.GovernmentID= CityCreateDTO.GovernmentID;
            
            //3- update  to city 
           await _cityReposatry.Update(city);

            //4- save to db 
          await  _cityReposatry.SaveAsync();

            // 3- city after update with navigation property
            var cityWithNavigation =  _cityReposatry.GetCity(c=>c.GovernmentID==city.GovernmentID).Result;

            //4- return cityReadDTO

             return new CityReadDTO()
            {
                Id = city.Id,
                Name = city.Name,
                GovernmentID = city.GovernmentID,
                GovernmentName = city.Government.Name,
                Status = city.Status
            };



            //var city = _cityReposatry.GetAllWithFilter(x => x.Id == id && x.IsDeleted == false).Result
            //    .Select(c => new CityReadDTO() {
            //        Name = c.Name,
            //        GovernmentID = c.GovernmentID,
            //        GovernmentName = c.Government.Name,
            //        Id = c.Id,
            //        NormalShippingCost = c.NormalShippingCost,
            //        PickupShippingCost = c.PickupShippingCost,
            //    }).FirstOrDefault();
            ////var city = await _cityReposatry.GetByIdAsync(id);

            //if (city != null)
            //{
            //    //mapping from CreateBranchDTO to Branch
            //    city.Name = CityCreateDTO.Name;
            //    city.GovernmentID = branchdto.GovernmentID;

            //    City updatedCity = _cityReposatry.Update(city).Result;
            //    await _cityReposatry.SaveAsync();

            //    //mapping from Branch to ReadBranchDTO
            //    return new CityReadDTO()
            //    {
            //        Id = updatedCity.Id,
            //        Name = updatedCity.Name,
            //        GovernmentID = updatedCity.GovernmentID,
            //        GovernmentName = iGenericStatusRepositoryGovernment.GetByIdAsync(updatedBranch.GovernmentID).Result.Name,
            //        IsDeleted = updatedCity.IsDeleted,
            //        Status = updatedCity.Status
            //    };
            //}
            //else
            //    return null;
        }


    }
}
