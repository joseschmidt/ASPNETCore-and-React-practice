using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using React.AspNet;
using ASPNETCore_React.Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore_React.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //React.NET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            //Configuring DBContext
            services.AddDbContext<DomainContext>();

            services.AddMvc();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureAppStaticFiles(app);

            //This is for Web API
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            }); 
        }

        /// <summary>
        /// Configure app static files
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureAppStaticFiles(IApplicationBuilder app)
        {
            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config
                //  .AddScript("~/Scripts/First.jsx")
                //  .AddScript("~/Scripts/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });

            //For wwwroot files
            app.UseStaticFiles();
        }
    }
}
