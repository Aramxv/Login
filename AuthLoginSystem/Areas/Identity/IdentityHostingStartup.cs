using System;
using AuthLoginSystem.Areas.Identity.Data;
using AuthLoginSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthLoginSystem.Areas.Identity.IdentityHostingStartup))]
namespace AuthLoginSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthLoginSystemDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthLoginSystemDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    // Turn off the Lower-UpperCase and Non Alphanumeric Char 
                    // in Password Requirements
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<AuthLoginSystemDbContext>();
            });
        }
    }
}