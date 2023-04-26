using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Common.Interfaces.Persistence;
using CaaoBakery.Application.Common.Services;
using CaaoBakery.Infrastructure.Authentication;
using CaaoBakery.Infrastructure.Persistence;
using CaaoBakery.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            ConfigurationManager configuration) {
            
            services.AddAuth(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
        public static IServiceCollection AddAuth(
           this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=> options.TokenValidationParameters =new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey= new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))

                });

            return services;
        }

    }
}
