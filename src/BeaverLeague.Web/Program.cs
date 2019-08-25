using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                             .UseStartup<Startup>();
        }
    }
}
