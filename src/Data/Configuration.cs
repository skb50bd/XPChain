using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Data.Persistence;

namespace Data
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureData(
            this IServiceCollection services)
        {
            services.AddTransient<IRepository, LiteDbRepository>();

            return services;
        }
    }
}
