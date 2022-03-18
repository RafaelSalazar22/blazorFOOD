using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proyecto_Food_Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proyecto_Food_Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddControllers();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            /*services.AddAuthentication("Cookies").AddCookie(opt =>
            {
                opt.Cookie.Name = "TryingoutGoogleOAuth";
                opt.LoginPath = "/auth/google-login";
                opt.LoginPath = "/auth/facebook-login";
                //opt.LoginPath = "/singin-google";

            })
                   .AddGoogle(opt =>
                   {
                       opt.ClientId = Configuration["Google:ClientId"];
                       opt.ClientSecret = Configuration["Google:ClientSecret"];
                       opt.Scope.Add("profile");
                       opt.Events.OnCreatingTicket = context =>
                       {
                           string picuri = context.User.GetProperty("picture").GetString();

                           context.Identity.AddClaim(new Claim("picture", picuri));
                           return Task.CompletedTask;
                       };
                   });
            */
            var httpClientHanler = new HttpClientHandler();
            httpClientHanler.ServerCertificateCustomValidationCallback =
                (messsage, cert, chain, error) => true;

            services.AddSingleton(new HttpClient(httpClientHanler)
            {
                BaseAddress = new Uri("https://localhost:44350")
            });
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
                app.UseExceptionHandler("/Error");
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
                endpoints.MapBlazorHub();
                endpoints.MapControllers();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}