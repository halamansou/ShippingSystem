
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
            builder.Services.AddScoped<IGenericStatusRepository<Government>, GenericStatusRepository<Government>>();
            builder.Services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            builder.Services.AddScoped<IGenericStatusRepository<Branch>, GenericStatusRepository<Branch>>();
            //builder.Services.AddScoped<IGenericStatusRepository<Government>, GenericStatusRepository<Government>>();
            builder.Services.AddScoped<IGenericRepository<ExistedEntities>, GenericRepository<ExistedEntities>>();

            //Delivery Accounts
            builder.Services.AddScoped<IGenericRepository<DeliveryAccount>, GenericRepository<DeliveryAccount>>();

            //builder.Services.AddScoped<IGenericRepository<Permission_User_Entities>, GenericRepository<Permission_User_Entities>>();
            builder.Services.AddScoped<EmployeeService>();
            //builder.Services.AddScoped<PermissionsService>();

            // Delivery Accounts Service
            builder.Services.AddScoped<DeliveryAccountService>();


            //Register Order Service
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<BranchService>();
            builder.Services.AddScoped<GovernmentService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            //Register City Service
            builder.Services.AddScoped<IGenericRepository<Government>, GenericRepository<Government>>();
            builder.Services.AddScoped<IGenericRepository<City>, GenericRepository<City>>();
            builder.Services.AddScoped< CityReposatry>();
            builder.Services.AddScoped<CityService>();



            //  add  CORS configuration:

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

         

            
            







            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}