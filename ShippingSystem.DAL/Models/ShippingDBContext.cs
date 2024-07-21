using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class ShippingDBContext : IdentityDbContext<Account, Role, int>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ExistedEntities> Entities { get; set; }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<MerchantAccount> MerchantAccounts { get; set; }
        public DbSet<DeliveryAccount> DeliveryAccounts { get; set; }


        public ShippingDBContext(DbContextOptions<ShippingDBContext> options) : base(options)
        {
        }

        public ShippingDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {




            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");


            //add data 


            builder.Entity<PaymentType>(entity => entity.HasData(
                new PaymentType { Id = 1, Name = "Cash" },
                new PaymentType { Id = 2, Name = "Visa" }

                ));

            builder.Entity<ShippingType>(entity => entity.HasData(
              new ShippingType { Id = 1, Name = "Normal", Price = 30 },
              new ShippingType { Id = 2, Name = "7 Days", Price = 50 },
              new ShippingType { Id = 3, Name = "24 Hour", Price = 70 }


              ));

            builder.Entity<Role>(entity => entity.HasData(
              new Role { Id = 1, Name = "Employee" },
              new Role { Id = 2, Name = "Merchant" },
              new Role { Id = 3, Name = "Delivery" },
              new Role { Id = 4, Name = "Admin" }
              ));

            builder.Entity<ExistedEntities>(entity => entity.HasData(
            new ExistedEntities { Id = 1, Name = "Settings" },
            new ExistedEntities { Id = 2, Name = "Branches" },
            new ExistedEntities { Id = 3, Name = "Employees" },
            new ExistedEntities { Id = 4, Name = "Merchants" },
            new ExistedEntities { Id = 5, Name = "Deliveries" },
            new ExistedEntities { Id = 6, Name = "Governorates" },
            new ExistedEntities { Id = 7, Name = "Cities" },
            new ExistedEntities { Id = 8, Name = "Orders" },
            new ExistedEntities { Id = 9, Name = "Financials" },
            new ExistedEntities { Id = 10, Name = "Reports" }
             ));
            // Seed initial account
            var hasher = new PasswordHasher<Account>();
            var newAccount = new Account
            {
                Id = 1,
                UserName = "newuser",
                Email = "newuser@example.com",
                Name = "New User",
                Address = "123 New Street",
                Status = true,
                RoleID = 1,
                PasswordHash = hasher.HashPassword(null, "password") // Set a default password
            };

            builder.Entity<Account>().HasData(newAccount);

            // Seed permissions for the new account
            builder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    RoleId = 1,
                    EntityId = 1, // Settings
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                },
                new Permission
                {
                    Id = 2,
                    RoleId = 1,
                    EntityId = 2, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 3,
                    RoleId = 1,
                    EntityId = 3, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 4,
                    RoleId = 1,
                    EntityId = 4, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 5,
                    RoleId = 1,
                    EntityId = 5, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 6,
                    RoleId = 1,
                    EntityId = 6, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 7,
                    RoleId = 1,
                    EntityId = 7, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 8,
                    RoleId = 1,
                    EntityId = 8, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 9,
                    RoleId = 1,
                    EntityId = 9, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 10,
                    RoleId = 1,
                    EntityId = 10, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }


            );
            // Seed data for the Government entity
            builder.Entity<Government>().HasData(
                new Government
                {
                    Id = 1,
                    Name = "Government1",
                    IsDeleted = false,
                    Status = true,
                    BranchID = null
                }
            );
            builder.Entity<Branch>().HasData(
               new Branch
               {
                   Id = 1,
                   Name = "Branch1",
                   IsDeleted = false,
                   Status = true,
                   CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                   GovernmentID = 1 // Ensure this ID exists in the Governments table
               },
               new Branch
               {
                   Id = 2,
                   Name = "Branch2",
                   IsDeleted = false,
                   Status = true,
                   CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                   GovernmentID = 2 // Ensure this ID exists in the Governments table
               }
           );
            builder.Entity<Government>().HasData(
                new Government
                {
                    Id = 2,
                    Name = "Government3",
                    IsDeleted = false,
                    Status = true,
                    BranchID = 1
                },
                new Government
                {
                    Id = 3,
                    Name = "Government2",
                    IsDeleted = false,
                    Status = true,
                    BranchID = 2
                }
            );
            builder.Entity<City>().HasData(
           new City
           {
               Id = 1,
               Name = "City1",
               IsDeleted = false,
               Status = true,
               NormalShippingCost = 10.00m,
               PickupShippingCost = 5.00m,
               GovernmentID = 1 // Ensure this ID exists in the Governments table
           },
           new City
           {
               Id = 2,
               Name = "City2",
               IsDeleted = false,
               Status = true,
               NormalShippingCost = 15.00m,
               PickupShippingCost = 7.00m,
               GovernmentID = 2 // Ensure this ID exists in the Governments table
           }
       );
            // Seed data for the MerchantAccount entity
            builder.Entity<MerchantAccount>().HasData(
                new MerchantAccount
                {
                    Id = 1,
                    UserName = "merchant1@example.com",
                    NormalizedUserName = "MERCHANT1@EXAMPLE.COM",
                    Email = "merchant1@example.com",
                    NormalizedEmail = "MERCHANT1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<MerchantAccount>().HashPassword(null, "Password@123"),
                    SecurityStamp = string.Empty,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Name = "Merchant 1",
                    Address = "123 Main St",
                    Status = true,
                    RoleID = 2, // RoleID for User role
                    BranchID = 1, // Ensure this ID exists in the Branches table
                    StoreName = "Merchant Store 1",
                    Government = "Government1", // Ensure this matches the Name in Governments table
                    City = "City1", // Ensure this matches the Name in Cities table
                    Pickup_Price = 5.00m,
                    Refund_Percentage = 10.00m
                },
                new MerchantAccount
                {
                    Id = 2,
                    UserName = "merchant2@example.com",
                    NormalizedUserName = "MERCHANT2@EXAMPLE.COM",
                    Email = "merchant2@example.com",
                    NormalizedEmail = "MERCHANT2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<MerchantAccount>().HashPassword(null, "Password@123"),
                    SecurityStamp = string.Empty,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    Name = "Merchant 2",
                    Address = "456 Elm St",
                    Status = true,
                    RoleID = 2, // RoleID for User role
                    BranchID = 2, // Ensure this ID exists in the Branches table
                    StoreName = "Merchant Store 2",
                    Government = "Government2", // Ensure this matches the Name in Governments table
                    City = "City2", // Ensure this matches the Name in Cities table
                    Pickup_Price = 7.00m,
                    Refund_Percentage = 15.00m
                }
            );
            base.OnModelCreating(builder);
        }
    }
}
