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

            ProcessDbCommands(args, host);

            host.Run();
        }

        private static void ProcessDbCommands(string[] args, IWebHost host)
        {
            if (args.Contains("dropdb"))
            {
                Console.WriteLine("Dropping database");
                var db = GetLeagueDb(host);
                db.Database.EnsureDeleted();
            }
            if (args.Contains("migratedb"))
            {
                Console.WriteLine("Migrating database");
                var db = GetLeagueDb(host);
                db.Database.Migrate();
            }
            if (args.Contains("seeddb"))
            {
                Console.WriteLine("Seeding database");
                var db = GetLeagueDb(host);
                db.Seed();
            }
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
