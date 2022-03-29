using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NegociaFacil.Application.Options.Jwt;
using NegociaFacil.Application.Services;
using NegociaFacil.Application.Services.Abstractions;
using NegociaFacil.Domain.Identity;
using NegociaFacil.Domain.Repositories;
using NegociaFacil.Domain.Shared.Notifications;
using NegociaFacil.Infra.Data.DBContext;
using System;
using System.Text;

namespace NegociaFacil.Infra.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterRepository(services, configuration);
            RegisterSwagger(services, configuration);
            RegisterAuthorizationAuthentication(services, configuration);
            RegisterDomainService(services);
            RegisterApplication(services);
            AddCustomOptions(services, configuration);
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
        }

        public static void AddCustomOptions(IServiceCollection services,
                                            IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Section));
        }

        private static void RegisterDomainService(IServiceCollection services)
        {
            services.AddScoped<INotificationDomainService, NotificationDomainService>();
        }

        private static void RegisterAuthorizationAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            // For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JwtOptions:ValidAudience"],
                    ValidIssuer = configuration["JwtOptions:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:SecretKey"]))
                };
            });
        }

        private static void RegisterSwagger(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Negocia Fácil",
                    Description = "Authentication and Authorization in ASP.NET 6 with JWT and Swagger"
                });

                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void RegisterRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, IUnitOfWork>();
        }
    }
}
