using System;
using Application.Areas.Identity.Data;
using Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Application.Areas.Identity.IdentityHostingStartup))]
namespace Application.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(
                        $"Server=localhost\\SQLEXPRESS01;Database={nameof(ApplicationContext)};Trusted_Connection=True;"));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<ApplicationContext>();
            });
        }
    }
}