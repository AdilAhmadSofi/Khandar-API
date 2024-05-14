 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Khandar.Application;
using Khandar.Persistence;
using Khandar.Infrastructure;
using Microsoft.OpenApi.Models;
using Khandar.Api.Middlewares;

namespace Khandar.Api
{
    public static class AssemblyReference
    {

        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eKhander API", Version = "v1" });
            });
            services.AddHttpContextAccessor();

            services.AddApplicationService(environment.WebRootPath)
            .AddInfrastructureService(configuration)  
            .AddPersistenceService(configuration);

            services.AddCors();

            services.AddAuthentication(options =>
            {

                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

            services.AddLogging();

            services.AddTransient<GlobalExceptionHandlingMiddleware>();

            return services;
        }
    }

}
