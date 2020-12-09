using System;
using System.Globalization;
using System.IO;
using System.Text;
using Labmark.Domain.Modules.Account;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));
            services.AddIdentity<Usuario, AppRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddRouting(options =>
            {
                options.LowercaseQueryStrings = true;
            });
            services.AddMvc(options => options.EnableEndpointRouting = false)
            .AddRazorRuntimeCompilation().AddRazorPagesOptions(options =>
            {
                options.RootDirectory = "/Pages";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api-labmark", Version = "v1" });
            });
            ContainerInjection.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch(AppError ex)
                {
                    string json = JsonConvert.SerializeObject(new ResponseDto("error", ex._message));
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = ex._statusCode;

                    await context.Response.WriteAsync(json);
                }catch(Exception ex)
                {
                    string json = JsonConvert.SerializeObject(new ResponseDto("error", ex.Message));
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;

                    await context.Response.WriteAsync(json);
                }
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
