using BeaverLeague.Core.Services;
using BeaverLeague.Data;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeaverLeague.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<LeagueData>();
            services.AddTransient<ISystemClock, SystemClock>();
            services.AddTransient<IMatchDayFinder, WednesdayMatchDayFinder>();
            services.AddDbContext<LeagueDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("LeagueDb")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseDeveloperExceptionPage();
            app.UseFileServer();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapRazorPages();
            });
        }
    }
}
