using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Core.Areas.Identity.IdentityHostingStartup))]
namespace Core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}