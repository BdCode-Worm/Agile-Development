using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMPReportingApp.Areas.Identity.Data;
using PMPReportingApp.Data;

[assembly: HostingStartup(typeof(PMPReportingApp.Areas.Identity.IdentityHostingStartup))]
namespace PMPReportingApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PMPReportingDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PMPReportingDBContextConnection")));

                services.AddDefaultIdentity<ReportingUser>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<PMPReportingDbContext>();
            });
        }
    }
}