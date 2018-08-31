using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        }

        public IConfiguration Configuration { get; protected set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();           
        }

        public void Configure(IApplicationBuilder app)
        {                       
            app.UseDeveloperExceptionPage();
            app.UseFileServer();
            app.UseMvc();
            app.UseBlazor<Client.Program>();
        }
    }
}
