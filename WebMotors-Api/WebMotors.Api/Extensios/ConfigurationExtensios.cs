using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Application;
using WebMotors.Application.Contract;
using WebMotors.Infrastructure;
using WebMotors.Infrastructure.Contract;

namespace WebMotors.Api.Extensios
{
    public static class ConfigurationExtensios
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAnuncioService, AnuncioService>();
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAnuncioRepo, AnuncioRepo>();
            return services;     
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
