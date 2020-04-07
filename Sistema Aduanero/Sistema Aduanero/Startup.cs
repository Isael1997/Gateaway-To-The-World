using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sistema_Aduanero.Services;

namespace Sistema_Aduanero
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
            services.AddDistributedMemoryCache();
            services.AddSession(option=> 
            {
                option.IdleTimeout = TimeSpan.FromDays(1);
                option.CookieName = "MySession";
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<ILogin, Login>();
            services.AddSingleton<IValidacion_De_Registros_Cliente, Validacion_De_Registros_Cliente>();
            services.AddSingleton<ICRUD_Usuario, CRUD_Usuario>();
            services.AddSingleton<ICRUD_Telefono_y_Correo, CRUD_Telefono_y_Correo>();
            services.AddSingleton<IValidacion_Solicitud_De_Servicio, Validacion_Solicitud_De_Servicio>();
            services.AddSingleton<ICRUD_Solicitud_De_Servicios, CRUD_Solicitud_De_Servicios>();
            services.AddSingleton<IFacturar_Servicio, Facturar_Servicio>();
            services.AddSingleton<IDeclarar, Declarar>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "empleado_ventana_perfil",
                    template: "{controller=Empleado}/{action=Perfil}/{id?}"
                );
                routes.MapRoute(
                    name: "empleado_ventana_listado_de_pedidos",
                    template: "{controller=Empleado}/{action=Listado_De_Solicitudes}/{id?}"
                );
                routes.MapRoute(
                    name: "eliminar",
                    template: "{controller=Cliente}/{action=Eliminar_Solicitud}/{id?}"
                );
                routes.MapRoute(
                    name: "empleado_ventana_envio",
                    template: "{controller=Empleado}/{action=Envio}/{id?}"
                );
                routes.MapRoute(
                    name: "empleado_ventana_declarar",
                    template: "{controller=Empleado}/{action=Declarar}/{id?}"
                );
                routes.MapRoute(
                    name: "empleado_ventana_Hacer_Entrega",
                    template: "{controller=Empleado}/{action=Hacer_Entrega}/{id?}"
                );
                routes.MapRoute(
                    name: "cliente_ventana_perfil",
                    template: "{controller=Cliente}/{action=Perfil}/{id?}"
                );
                routes.MapRoute(
                    name: "cliente_ventana_listado_solicitudes_realizadas",
                    template: "{controller=Cliente}/{action=Listado_De_Servicios_Contratados}/{id?}"
                );
                routes.MapRoute(
                    name: "cliente_formulario_para_Servicio_De_Importacion_O_Exportacion",
                    template: "{controller=Cliente}/{action=Solicitar_Servicio_De_Importacion_O_Exportacion}/{id?}"
                );
                routes.MapRoute(
                    name: "Facturacion",
                    template: "{controller=Cliente}/{action=Facturar}/{id?}"
                );
            });
        }
    }
}
