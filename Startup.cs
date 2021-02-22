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
using Clinic.Web.BLL.Interfaces;
using Clinic.Web.BLL.Services;
using Clinic.Web.DAL.ADO;

namespace Clinic.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<Clinic.Web.DAL.Abstract.ISpecialtiesRepository, SpecialtiesRepository>();
            services.AddTransient<Clinic.Web.DAL.Abstract.IDoctorsRepository, DoctorsRepository>();
            services.AddTransient<Clinic.Web.BLL.Interfaces.ISpecialtiesManager, SpecialtiesManager>();
            services.AddTransient<Clinic.Web.BLL.Interfaces.IDoctorsManager, DoctorsManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
