using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Common.Services;
using CaaoBakery.Application.Persistence;
using CaaoBakery.Infrastructure.Authentication;
using CaaoBakery.Infrastructure.Persistence;
using CaaoBakery.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaaoBakery.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration) {

            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }

    }
}
