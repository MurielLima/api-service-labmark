using System;
using System.Globalization;
using Labmark.Domain;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Labmark
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
            // Connections
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            // Identity
            services.AddIdentity<Usuario, AppRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            // Configs to Routes
            services.AddRouting(options =>
            {
                options.LowercaseQueryStrings = true;
            });
            //Add Front-end Pages
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(typeof(CustomExceptionFilter));
            })
            .AddRazorRuntimeCompilation().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages";
            });
            // Documentation Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api-labmark", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName.Replace("Labmark.Domain.Modules.", "").Replace("Infrastructure.Models.Dtos.", ""));
            });

            services.AddHealthChecks();
            services.AddLogging();

            //Dependency Injection
            DependencyInjection.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // Language Support
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api-labmark v1"));
            }
            else
            {
                app.UseExceptionHandler("/Shared/NotFound");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            try
            {
                //Run migrations
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                            .Database.Migrate();
                }
            }
            catch (Exception ex){
            }
            app.UseFastReport();
            app.UseDefaultFiles();
            app.UseHealthChecks("/api/health");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseMiddleware<MiddlewareValidation>();
            app.UseRouting();

            //Default Route
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

        }

    }

}
