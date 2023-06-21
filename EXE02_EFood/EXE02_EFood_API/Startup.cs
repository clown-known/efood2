using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;                                    
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace EXE02_EFood_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<E_FoodContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnect")));
            services.AddControllers();
            services.AddScoped<IRestaurantRepository, RestaurantRepositoryImp>();
            services.AddScoped<IAccountRepository, AccountRepositoryImp>();
            services.AddScoped<IDishCategoryRepository, DishCategoryRepositoryImp>();
            services.AddScoped<IDishRepository, DishRepositoryImp>();
            services.AddScoped<ICategoryRepository, CategoryRepositoryImp>();
            services.AddScoped<IUserRepository, UserRepositoryImp>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepositoryImp>();
            services.AddScoped<IMenuRepository, MenuRepositoryImp>();
            services.AddScoped<IReviewOfResRepo, ReviewOfResRepoImp>();
            services.AddScoped<IRestaurantManagerRepository, RestaurantManagerRepository>();
            services.AddScoped<IReviewOfDishRepository, ReviewOfDishRepositoryImp>();
            services.AddScoped<IRestaurantManagerRepository, RestaurantManagerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepositoryImp>();
            services.AddScoped<IAccountPaymentRepository, AccountPaymentRepositoryImp>();
            services.AddScoped<IPremiumRepository, PremiumRepositoryImp>();
            services.AddScoped<IPremium_hisRepository, Premium_hisRepositoryImp>();
            services.AddScoped<IUserNotifyRepository, UserNotifyRepositoryImp>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EXE02_EFood_API", Version = "v1" });
            });

            //services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EXE02_EFood_API v1"));
                app.UseSwaggerUI();

            app.UseCors();
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
