using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web
{
    public class Startup
    {      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            if (!environment.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseMvc();
        }
    }
}
