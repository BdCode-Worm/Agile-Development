using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMPReportingTool.Areas.Identity.Data;
using PMPReportingTool.Data;

[assembly: HostingStartup(typeof(PMPReportingTool.Areas.Identity.IdentityHostingStartup))]
namespace PMPReportingTool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PMPReportingDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PMPReportingDBContextConnection")));

                services.AddDefaultIdentity<PMPReportingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PMPReportingDBContext>();
            });
        }
    }
}