using System;
using it_shop_app.Areas.Identity.Data;
using it_shop_app.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(it_shop_app.Areas.Identity.IdentityHostingStartup))]
namespace it_shop_app.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShopContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopContext")));

                services.AddDefaultIdentity<IdentityNutzer>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ShopContext>();
            });
        }
    }
}