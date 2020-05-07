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
using ITLabNET.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using ITLabNET.Models.Domain.Sessies;
using ITLabNET.Models.Domain.Gebruikers;
using ITLabNET.Data.Repositories;
using ITLabNET.Models.Domain;

namespace ITLabNET
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Hoofdverantwoordelijke", policy => policy.RequireClaim(ClaimTypes.Role, "Hoofdverantwoordelijke"));
                options.AddPolicy("Verantwoordelijke", policy => policy.RequireClaim(ClaimTypes.Role, "Verantwoordelijke"));
                options.AddPolicy("Gebruiker", policy => policy.RequireClaim(ClaimTypes.Role, "Gebruiker"));
            });   


            services
                .AddScoped<DataInitializer>()
                .AddScoped<ISessieRepository, SessieRepository>()
                .AddScoped<IGebruikerRepository, GebruikerRepository>()
                .AddScoped<IFeedbackRepository, FeedbackRepository>();

            services
                .AddControllersWithViews();               

            services.AddRazorPages();

            services.AddSession();
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataInitializer dataInitializer)
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

            app.UseSession();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.ToLower().StartsWith("/identity/account/register"))
                {
                    context.Response.StatusCode = 404; //Not found
                    return;
                }
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Sessie}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            dataInitializer.InitializeData().Wait();
        }
    }
}
