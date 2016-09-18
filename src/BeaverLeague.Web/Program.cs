using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BeaverLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BeaverLeague.Data.Seed;

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
                Console.WriteLine("Migrating database");
                var db = GetLeagueDb(host);                
                db.Database.Migrate();
            }
            if (args.Contains("seed"))
            {
                Console.WriteLine("Seeding database");
                var db = GetLeagueDb(host);
                db.Seed();
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
