using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Fitness.Web.Areas.Identity.IdentityHostingStartup))]

namespace Fitness.Web.Areas.Identity
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
