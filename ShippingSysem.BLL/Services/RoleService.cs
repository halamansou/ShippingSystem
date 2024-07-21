using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using ShippingSysem.BLL.DTOs.PermissionsDTOS;
using ShippingSysem.BLL.DTOs.RoleDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class RoleService
    {
        private readonly IGenericRepository<Account> AccgenRepo;
        private readonly IGenericRepository<Role> RolegenRepo;

        private ShippingDBContext dbContext;


        public RoleService(ShippingDBContext dbContext, IGenericRepository<Account> AccgenRepo, IGenericRepository<Role> RolegenRepo)
        {

            this.dbContext = dbContext;
            this.AccgenRepo = AccgenRepo;
            this.RolegenRepo = RolegenRepo;
        }


        public async Task<List<RoleDTO>> GetAllRoles()
        {
            var roles = await RolegenRepo.GetAllAsync();
            var allRoles = roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                CreatedDate = r.CreatedDate
            }).ToList();

            return allRoles;
        }

        public async Task<Role> GetRole(int id)
        {
            var role = await RolegenRepo.GetByIdAsync(id);


            return role;
        }

        public async Task<Role> UpdateRole(int id, string rolename)
        {
            var role = await RolegenRepo.GetByIdAsync(id);
            role.Name = rolename;
            await RolegenRepo.SaveAsync();
            return role;
        }

        public Task<List<PermissionDTO>> GetAllRolePermissionsForUser(int roleid)
        {
            var acc = dbContext.Set<Permission>().Where(i => i.RoleId == roleid && i.role.IsDeleted == false).Select(a => new PermissionDTO
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

        public async Task<Role> AddRole(string RoleName)
        {
            Role role = new Role() { Name = RoleName };
            // Create permissions for all entities with default values (false)
            var entityPermissions = await dbContext.Set<ExistedEntities>().ToListAsync(); // Assuming you have an entity for entities with IDs
            var permissions = entityPermissions.Select(entity => new Permission
            {
                RoleId = role.Id,
                EntityId = entity.Id,
                CanRead = false,
                CanWrite = false,
                CanDelete = false,
                CanCreate = false
            }).ToList();

            // Add permissions to the account
            role.Permissions = permissions;
            await RolegenRepo.AddAsync(role);
            await RolegenRepo.SaveAsync();
            return (role);
        }

        public async Task<bool> UpdateRolePermissionsForUser(int id, List<PermissionDTO> permissions)
        {
            var role = await dbContext.Set<Role>()
                                    .Include(e => e.Permissions)
                                    .FirstOrDefaultAsync(i => i.Id == id && i.IsDeleted == false);

            if (role == null)
            {
                throw new ArgumentException($"Account with ID {id} not found.");
            }


            // Update permissions based on permissionDtos
            foreach (var permissionDto in permissions)
            {
                var existingPermission = role.Permissions.FirstOrDefault(p => p.EntityId == permissionDto.EntityId);

                if (existingPermission != null)
                {
                    existingPermission.CanRead = permissionDto.CanRead;
                    existingPermission.CanWrite = permissionDto.CanWrite;
                    existingPermission.CanDelete = permissionDto.CanDelete;
                    existingPermission.CanCreate = permissionDto.CanCreate;
                }

            }
            await RolegenRepo.SaveAsync();
            return true;

        }


        public async Task<Role> DeleteRole(int id)
        {
            var entity = await RolegenRepo.DeleteById(id);
            return (entity);
        }

    }
}
