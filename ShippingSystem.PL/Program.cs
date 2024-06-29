
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories;
using ShippingSystem.DAL.Repositories.Base;

namespace ShippingSystem.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Services 
            builder.Services.AddDbContext<ShippingDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });
            builder.Services.AddIdentity<Account, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();

            builder.Services.AddIdentityCore<DeliveryAccount>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();

            builder.Services.AddIdentityCore<MerchantAccount>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = false;
                // Adjust other password settings as necessary
                options.Password.RequiredLength = 6;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ShippingDBContext>();



            //Register Emp Services 
            builder.Services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            builder.Services.AddScoped<IGenericRepository<ExistedEntities>, GenericRepository<ExistedEntities>>();

            //Delivery Accounts
            builder.Services.AddScoped<IGenericRepository<DeliveryAccount>, GenericRepository<DeliveryAccount>>();

            //builder.Services.AddScoped<IGenericRepository<Permission_User_Entities>, GenericRepository<Permission_User_Entities>>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<PermissionsService>();

            // Delivery Accounts Service
            builder.Services.AddScoped< DeliveryAccountService>();


            //Register Order Service
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<OrderService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
