using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Common.Interfaces.Persistence;
using CaaoBakery.Application.Common.Services;
using CaaoBakery.Infrastructure.Authentication;
using CaaoBakery.Infrastructure.Persistence;
using CaaoBakery.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CaaoBakery.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ;
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");


            services.AddDbContext<CaaoBakeryDbContext>(options =>
                options.UseSqlServer(
                    $"Server={dbHost};Database={dbName};User=sa;Password={dbPassword};TrustServerCertificate=true"));

            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }

        public static IServiceCollection AddAuth(
                this IServiceCollection services,
                ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                });

            return services;
        }
    }
}
