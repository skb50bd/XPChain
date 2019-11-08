using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureData(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IRepository, LiteDbRepository>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
