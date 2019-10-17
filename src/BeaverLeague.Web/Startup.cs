using BeaverLeague.Core.Services;
using BeaverLeague.Data;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BeaverLeague.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<ISystemClock, SystemClock>();
            services.AddTransient<IMatchDayFinder, WednesdayMatchDayFinder>();
            services.AddScoped<LeagueData>();

            if(environment.IsDevelopment() || environment.IsProduction())
            {
                services.AddDbContextPool<LeagueDbContext>(
                    c => c.UseSqlServer(configuration.GetConnectionString("LeagueDb")));
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapBlazorHub();
                e.MapRazorPages();
            });
        }
    }
}
