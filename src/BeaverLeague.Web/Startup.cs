using BeaverLeague.Data;
using BeaverLeague.Web.Security;
using BeaverLeague.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;

namespace BeaverLeague.Web
{    
    public class Startup
    {
        public Startup(IHostingEnvironment environment, ILoggerFactory loggerFactory)
        {
            Configuration =
                new ConfigurationBuilder()
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               //.WriteTo.RollingFile(new JsonFormatter(), "log-{Date}.json")
               .CreateLogger();
            loggerFactory.AddSerilog();
        }

        public IConfiguration Configuration { get; protected set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSecurity();
            services.AddCustomMediator();
            services.AddDataStores(Configuration.GetConnectionString(nameof(LeagueDb)));            
        }

        public void Configure(IApplicationBuilder app)
        {                       
            app.UseDeveloperExceptionPage();
            app.UseFileServer();
            app.UseCookieAuthentication(AppCookieAuthentication.Options);
            app.UseMvc();
        }
    }
}
