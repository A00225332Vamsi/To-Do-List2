using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList1.Models;
using WebEssentials.AspNetCore.Pwa;

namespace TodoList1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable TLS 1.2 before connecting to Azure Storage
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("ToDoDBConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            //Turning a ASP.NET Core website into a Progressive Web App (PWA)
            
            services.AddProgressiveWebApp();
            //services.AddProgressiveWebApp(new PwaOptions
            //{
            //    CacheId = "Worker " + 1,
            //    Strategy = ServiceWorkerStrategy.CacheFirst,
            //    RoutesToPreCache = "/Home/Index",
            //    OfflineRoute = "/Home/home1, /Account/Register",
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Add static files Middleware
            app.UseStaticFiles();
            app.UseAuthentication();
            //MVC default route
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(route =>
            {
                route.MapRoute("defalt", "{controller=home}/{action=home1}/{id?}");
            });

        }
    }
}
