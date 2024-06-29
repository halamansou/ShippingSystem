using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class PermissionsService
    {
        private readonly IGenericRepository<AccessedEntity> genRepo;
        private readonly ShippingDBContext dbContext;


        public PermissionsService(IGenericRepository<AccessedEntity> genRepo, ShippingDBContext dbContext)
        {
            this.genRepo = genRepo;
            this.dbContext = dbContext;
        }

        public List<string> GetAllPermissionsForUser()
        {
            try
            {
                var permissions = dbContext.Accounts.Select(s => s.).ToList();

                return permissions;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // logger.LogError(ex, "An error occurred while fetching permissions for user with ID {UserId}", userId);

                // Return an empty list to maintain the expected return type
                return new List<string>();
            }
        }
    }
}
