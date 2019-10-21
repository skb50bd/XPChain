using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using XPData.Persistence;

namespace XPData
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureData(
            this IServiceCollection services)
        {
            services.ConfigureOptions<LiteSettings>();
            services.AddTransient<IRepository, LiteDbRepository>();

            return services;
        }
    }
}
