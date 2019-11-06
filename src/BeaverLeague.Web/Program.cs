using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BeaverLeague.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            var host = builder.Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(c =>
                       {
                           c.UseStartup<Startup>();
                       });
        }
    }
}
