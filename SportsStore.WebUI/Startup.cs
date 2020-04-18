using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI
{
    public class Startup
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration Configuration;

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IProductRepository, EFProductRepository>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                Configuration.GetConnectionString("");
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                //app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseSession();
                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "",
                        defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 }
                    );
                    endpoints.MapControllerRoute(
                      name: null,
                      pattern: "Page{page}",
                      defaults: new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" }

                    );
                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "{page}",
                        defaults: new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" }
                    );
                    endpoints.MapControllerRoute(
                       name: null,
                       pattern: "{category}",
                       defaults: new { controller = "Product", action = "List", page=1 }
                    );
                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "{category}/Page{page}",
                        defaults: new { controller = "Product", action = "List"}, new { page = @"\d+"}
                    );
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Product}/{action=List}/{id?}");
                    endpoints.MapControllerRoute(
                       name: "Cart",
                       pattern: "Cart/Index");
                });
            }
        }
    }
}
