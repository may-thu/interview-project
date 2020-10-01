using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVoucherManagementSystem.Database;
using eVoucherManagementSystem.Infrastrature;
using eVoucherManagementSystem.Models;
using eVoucherManagementSystem.Repositories;
using eVoucherManagementSystem.Repositories.Implementations;
using eVoucherManagementSystem.Services;
using eVoucherManagementSystem.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace eVoucherManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add servic    es to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "eVoucherManagementSystem Rest API", Version = "1" });
            });

            services.AddDbContext<eVoucherMSDBContext>(op => op.UseSqlServer(Configuration["ConnectionString:eVoucherMSDB"]));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<eVoucherMSDBContext>();

            services.AddJwtAuth(Configuration);

            services.AddTransient<IeVoucherRepository, eVoucherRepository>();
            services.AddTransient<IQRCodeRepository, QRCodeRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IeStoreRepository, eStoreRepository>();
            services.AddTransient<IeVoucherService, eVoucherService>();
            services.AddTransient<IQRCodeService, QRCodeService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IeStore, eStoreService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Building Materials E-Store V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Run(async(context)=>{
            //    await context.Response.WriteAsync("Please wait a moment!");
            //});
        }
    }
}
