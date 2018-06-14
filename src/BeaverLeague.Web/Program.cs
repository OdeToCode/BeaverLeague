using System.IO;
using Microsoft.AspNetCore.Hosting;
using BeaverLeague.Web.Data;

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

            var dbCommands = new DbCommands(args, host);
            dbCommands.Process();

            host.Run();
        }
    }
}
