using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Matricula.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Matricula
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Users",
                    areaName: "Users",
                    pattern: "{controller=Users}/{action=Users}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Principal",
                    areaName: "Principal",
                    pattern: "{controller=Principal}/{action=Principal}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=Mantenimiento}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoCo_Requesitos}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoRequesitos}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoHorarios}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoPeriodos}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoMaterias}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoCarreras}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Mantenimiento",
                    areaName: "Mantenimiento",
                    pattern: "{controller=Mantenimiento}/{action=listadoPlanes_Estudios}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Matricular",
                    areaName: "Matricular",
                    pattern: "{controller=Matricular}/{action=Matricular}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                    name: "Notas",
                    areaName: "Notas",
                    pattern: "{controller=Notas}/{action=InscripcionMaterias}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
