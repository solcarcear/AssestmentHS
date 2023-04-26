using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CaaoBakery.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using CaaoBakery.Api.Mapping;

namespace CaaoBakery.Api
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CaaoBakeryProblemDetailsFactory>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

    }
}
