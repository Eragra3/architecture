using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KekManager.Database.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using KekManager.DependancyRegistration;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using KekManager.Security.Domain;
using KekManager.Database;

namespace KekManager.AppStartup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FullDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("KekManager")));

            services.AddIdentity<SecurityUser, IdentityRole>()
                .AddEntityFrameworkStores<FullDatabaseContext>()
                .AddDefaultTokenProviders();

            services
                .AddMvc()
                .AddApplicationPart(Assembly.Load("KekManager.Api"))
                .AddApplicationPart(Assembly.Load("KekManager.Security.Api"));

            // Fix resolving views from different assemblies
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(Assembly.Load("KekManager.Api")));
                options.FileProviders.Add(new EmbeddedFileProvider(Assembly.Load("KekManager.Security.Api")));
            });

            // Add Autofac
            var harvester = new DependancyHarvester();
            var containerBuilder = harvester.Harvest();
            containerBuilder.Populate(services);
            containerBuilder.RegisterType<FullDatabaseContext>().AsSelf().InstancePerLifetimeScope();
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            // Seed database
            // NOTE: you need to comment db seeding when using migrations, it may cause 'object not found' errors
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

                await dbInitializer.Initialize();
            }
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
