using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BeaverLeague.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json")
                           .AddEnvironmentVariables();
                })
                .CaptureStartupErrors(true)
                .Build();
            
            host.Run();
        }
    }
}
