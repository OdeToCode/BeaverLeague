using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BeaverLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
         
            if (args.Contains("migrate"))
            {
                var db = GetLeagueDb(host);
                Console.WriteLine("Migrating database");
                db.Database.Migrate();
            }
            if (args.Contains("seed"))
            {
                var db = GetLeagueDb(host);
                Console.WriteLine("Seeding database");
            }

            host.Run();
        }

        private static LeagueDb GetLeagueDb(IWebHost host)
        {
            var db = host.Services.GetService(typeof(LeagueDb)) as LeagueDb;
            if (db == null)
            {
                throw new InvalidOperationException("Could not create LeagueDb");
            }
            return db;
        }
    }
}
