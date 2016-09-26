using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BeaverLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BeaverLeague.Web.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            ProcessDbCommands(args, host);

            host.Run();
        }

        private static void ProcessDbCommands(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                if (args.Contains("dropdb"))
                {
                    Console.WriteLine("Dropping database");
                    var db = GetLeagueDb(scope);
                    db.Database.EnsureDeleted();
                }
                if (args.Contains("migratedb"))
                {
                    Console.WriteLine("Migrating database");
                    var db = GetLeagueDb(scope);
                    db.Database.Migrate();
                }
                if (args.Contains("seeddb"))
                {
                    Console.WriteLine("Seeding database");
                    var db = GetLeagueDb(scope);
                    db.Seed();
                }
            }        
        }

        private static LeagueDb GetLeagueDb(IServiceScope services)
        {
            var db = services.ServiceProvider.GetRequiredService<LeagueDb>();           
            return db;
        }
    }
}
