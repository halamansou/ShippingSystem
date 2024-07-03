
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Account> genRepo;
        private readonly UserManager<Account> userManager;
        private readonly ShippingDBContext dbContext;

        public EmployeeService(IGenericRepository<Account> genRepo, UserManager<Account> userManager, ShippingDBContext dbContext)
        {
            this.genRepo = genRepo;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }



        public async Task<IdentityResult> AddEmp(CreateEmployeeDTO EmpDto)
        {

            Account acc = new Account()
            {
                UserName = EmpDto.email,
                Name = EmpDto.name,
                PhoneNumber = EmpDto.phone,
                Address = EmpDto.address,
                BranchID = EmpDto.BranchId,
                RoleID = EmpDto.RoleId,
                Email = EmpDto.email,
                Status = EmpDto.Status


            };



            var result = await userManager.CreateAsync(acc, EmpDto.password);
            if (result.Succeeded)
            {

                return result;
            }
            else
            {
                // Handle errors (e.g., log them or throw an exception)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<List<ReadEmployeeDTO>> GetAllEmps()
        {
            var accounts = await genRepo.GetAllAsync();

            var dtos = accounts.Where(e => e.Role.Name == "Employee")
                .Select(acc =>
                new ReadEmployeeDTO
                {
                    id = acc.Id,
                    name = acc.Name,
                    BranchName = acc.Branch.Name,
                    email = acc.Email,
                    phone = acc.PhoneNumber,
                    Status = acc.Status,
                    RoleName = acc.Role.Name
                }).ToList();

            return dtos;
        }


        public async Task<ReadEmployeeDTO> GetEmpById(int id)
        {
            //var acc = await genRepo.GetByIdAsync(id);
            var acc = await dbContext.Accounts
                    .Include(e => e.Branch)
                    .Include(e => e.Role)
                    .FirstOrDefaultAsync(e => e.Id == id);

            if (acc != null)
            {
                var EmpDTO = new ReadEmployeeDTO()
                {
                    id = acc.Id,
                    name = acc.Name,
                    address = acc.Address,
                    BranchName = acc.Branch?.Name,
                    branchId = acc.BranchID,
                    roleId = acc.RoleID,
                    email = acc.Email,
                    phone = acc.PhoneNumber,
                    RoleName = acc.Role?.Name, // Safe navigation operator
                    Status = acc.Status
                };
                return EmpDTO;
            }
            else
            {

                throw new Exception("Failed To Get Employee Data");
            }


        }


        public async Task<Account> UpdateEmp(int id, CreateEmployeeDTO empDto)
        {
            var acc = await genRepo.GetByIdAsync(id);
            if (acc == null)
            {
                throw new Exception("Employee doesn't exist");
            }

            acc.Name = empDto.name;
            acc.PhoneNumber = empDto.phone;
            acc.Address = empDto.address;
            acc.BranchID = empDto.BranchId;
            acc.RoleID = empDto.RoleId;
            acc.Email = empDto.email;


            // Assuming the password is hashed before storing
            acc.PasswordHash = empDto.password;

            await genRepo.SaveAsync();
            return acc;
        }



        public async Task<bool> UpdateEmpStatus(int id)
        {
            var acc = await genRepo.GetByIdAsync(id);
            acc.Status = !acc.Status;
            await genRepo.SaveAsync();
            if (acc != null) return true;
            return false;
        }
        public async Task<Account> DeleteEmpByID(int id)
        {
            var acc = await genRepo.DeleteById(id);
            await genRepo.SaveAsync();
            return acc;
        }
    }
}
