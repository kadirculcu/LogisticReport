using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Authentication;
using Business.IService;
using Business.Service;
using Core.DataAccess;
using Core.DataAccess.EntityFrameworkRepository;
using DataAccess.Authentication;
using DataAccess.Context;
using DataAccess.DataAccess;
using DataAccess.IDataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebUI
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
            services.AddControllers();

            services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            #region DbContext
            services.AddTransient<DbContext, ReportContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityFrameworkRepository<>));
            #endregion

            #region DataAccessService
            services.AddTransient<ReportContext>();
            services.AddTransient<IActionTypeDal, ActionTypeDal>();
            services.AddTransient<IMaintenanceDal, MaintenanceDal>();
            services.AddTransient<IMaintenanceHistoryDal, MaintenanceHistoryDal>();
            services.AddTransient<IPictureGroupDal, PictureGroupDal>();
            services.AddTransient<IStatusDal, StatusDal>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<IVehicleDal, VehicleDal>();
            services.AddTransient<IVehicleTypeDal, VehicleTypeDal>();
            services.AddTransient<IAuthenticationUserDal, AuthenticationUserDal>();
            #endregion

            #region BusinessService
            services.AddTransient<IMaintenanceService, MaintenenceService>();
            services.AddTransient<IPictureGroupService, PictureGroupService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            #endregion

            #region Swaggeer
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // To Enable authorization using Swagger (JWT)  
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                // To Enable authorization using Swagger (JWT)  
            });
            #endregion
            #region JWT
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false                    
                };
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            #region JWT
            app.UseAuthentication();
            #endregion

           app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swaggeer
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });
            #endregion         
            
        }
    }
}
