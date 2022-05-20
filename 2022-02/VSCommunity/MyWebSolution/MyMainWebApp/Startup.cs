using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMainWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Initialize connection to a DB > Entity Framework
            // Initialize Authentication mechanism

            // enables the use of MVC controllers and views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // enable MVC pattern
            app.UseRouting();

            app.UseAuthorization();

            // configures routing in MVC pattern
            // add custom and specific routes first and then generic ones last
            app.UseEndpoints(endpoints =>
            {
                // custom routes
                //endpoints.MapControllerRoute(
                //    name: "route-today",
                //    pattern: "today/{controller=date}/{action=day}/{offset=0}",
                //    dataTokens: new { source = "today" });
                //endpoints.MapControllerRoute(
                //        name: "route-yesterday",
                //        pattern: "yesterday/{controller=date}/{action=day}/{offset=-1}",
                //        dataTokens: new { source = "yesterday" });
                //endpoints.MapControllerRoute(
                //    name: "route-tomorrow",
                //    pattern: "tomorrow/{controller=date}/{action=day}/{offset=1}",
                //    dataTokens: new { source = "tomorrow" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
                      

        }
    }
}
