using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BeaverLeague.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();
            host.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .ConfigureWebHost(c =>
                        {
                            c.UseStartup<Startup>();
                        });
        }
    }
}
