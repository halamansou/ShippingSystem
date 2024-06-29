using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using ShippingSysem.BLL.DTOs.PermissionsDTOS;
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
        private readonly IGenericRepository<Account> genRepo;

        private ShippingDBContext dbContext;


        public PermissionsService(ShippingDBContext dbContext, IGenericRepository<Account> genRepo)
        {

            this.dbContext = dbContext;
            this.genRepo = genRepo;
        }




        public Task<List<PermissionDTO>> GetAllPermissionsForUser(int userId)
        {
            var acc = dbContext.Set<Permission>().Where(i => i.AccountId == userId).Select(a => new PermissionDTO
            {
                EntityId = a.Entity.Id,
                EntityName = a.Entity.Name,
                CanRead = a.CanRead,
                CanWrite = a.CanWrite,
                CanDelete = a.CanDelete,
                CanCreate = a.CanCreate
            }).ToList();


            return Task.FromResult(acc);
        }

        public async Task<bool> UpdatePermissionsForUser(int id, List<PermissionDTO> permissions)
        {
            var account = await dbContext.Set<Account>()
                                    .Include(e => e.Permissions)
                                    .FirstOrDefaultAsync(i => i.Id == id);

            if (account == null)
            {
                throw new ArgumentException($"Account with ID {id} not found.");
            }


            // Update permissions based on permissionDtos
            foreach (var permissionDto in permissions)
            {
                var existingPermission = account.Permissions.FirstOrDefault(p => p.EntityId == permissionDto.EntityId);

                if (existingPermission != null)
                {
                    existingPermission.CanRead = permissionDto.CanRead;
                    existingPermission.CanWrite = permissionDto.CanWrite;
                    existingPermission.CanDelete = permissionDto.CanDelete;
                    existingPermission.CanCreate = permissionDto.CanCreate;
                }

            }
            await genRepo.SaveAsync();
            return true;

        }



    }
}
