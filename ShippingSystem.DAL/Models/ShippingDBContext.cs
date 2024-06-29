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
        public DbSet<Account> Accounts;
        public DbSet<Role> Roles;
        public DbSet<Permission> Permissions;
        public DbSet<AccessedEntity> Entities;
        public DbSet<Permission_User_Entities> Permissions_User_Entities;
        public DbSet<Branch> Branches;
        public DbSet<City> Cities;
        public DbSet<Government> Governments;
        public DbSet<Order> Orders;
        public DbSet<Product> Products;
        public DbSet<PaymentType> PaymentTypes;
        public DbSet<ShippingType> ShippingTypes;
        public DbSet<MerchantAccount> MerchantAccounts;
        public DbSet<DeliveryAccount> DeliveryAccounts;


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
            //builder.Entity<OrderDetails>().HasKey("OrderId", "ProductId");
            builder.Entity<Permission_User_Entities>().HasKey("user_id", "permission_id", "entity_id");


            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");


            //add data 
            builder.Entity<Permission>(entity => entity.HasData(

                new Permission { Id = 1, Name = "Create" },
                new Permission { Id = 2, Name = "Update" },
                new Permission { Id = 3, Name = "Delete" },
                new Permission { Id = 4, Name = "Read" }
                ));

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
              new Role { Id = 1, Name = "Merchant" },
              new Role { Id = 2, Name = "Employee" },
              new Role { Id = 3, Name = "Delivery" },
              new Role { Id = 4, Name = "Admin" }
              ));

            builder.Entity<AccessedEntity>(entity => entity.HasData(
            new AccessedEntity { Id = 1, Name = "Settings" },
            new AccessedEntity { Id = 2, Name = "Branches" },
            new AccessedEntity { Id = 3, Name = "Employees" },
            new AccessedEntity { Id = 4, Name = "Merchants" },
            new AccessedEntity { Id = 5, Name = "Deliveries" },
            new AccessedEntity { Id = 6, Name = "Governorates" },
            new AccessedEntity { Id = 7, Name = "Cities" },
            new AccessedEntity { Id = 8, Name = "Orders" },
            new AccessedEntity { Id = 9, Name = "Financials" },
            new AccessedEntity { Id = 10, Name = "Reports" }
             ));
            base.OnModelCreating(builder);
        }
    }
}
