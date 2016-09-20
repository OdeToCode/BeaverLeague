using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BeaverLeague.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration =
                new ConfigurationBuilder()
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
        }

        public IConfiguration Configuration { get; protected set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomizedMvc();
            services.AddMediatR(typeof(Startup));
            services.AddDataStores(Configuration.GetConnectionString(nameof(LeagueDb)));
            services.AddIdentityAndAuthorization();

            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseIdentity();
            app.UseMvc();
        }
    }
}
