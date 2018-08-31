using System.IO;
using Microsoft.AspNetCore.Hosting;

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
                    // todo move config here
                })
                .ConfigureLogging(builder =>
                {
                    // todo move logging here
                })
                .CaptureStartupErrors(true)
                .Build();
            
            host.Run();
        }
    }
}
