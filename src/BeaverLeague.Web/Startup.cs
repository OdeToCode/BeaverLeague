using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeaverLeague.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/Error");
            app.UseHsts();
            app.UseFileServer();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseEndpoints(c =>
            {
                c.MapControllers();
                c.MapRazorPages();
            });
        }
    }
}
