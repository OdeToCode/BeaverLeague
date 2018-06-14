using BeaverLeague.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BeaverLeague.Web.Data
{
    public class DbCommands
    {
        private readonly string[] args;
        private readonly IWebHost host;

        public DbCommands(string[] args, IWebHost host)
        {
            this.args = args;
            this.host = host;
        }

        public void Process()
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LeagueDb>();

                if (args.Contains("dropdb"))
                {
                    Console.WriteLine("Dropping database");
                    db.Database.EnsureDeleted();
                }
                if (args.Contains("migratedb"))
                {
                    Console.WriteLine("Migrating database");
                    db.Database.Migrate();
                }
                if (args.Contains("seeddb"))
                {
                    Console.WriteLine("Seeding database");
                    db.Seed();
                }
            }

            if (args.Contains("stop"))
            {
                Console.WriteLine("Exiting on stop command");
                Environment.Exit(0);
            }
        }
    }
}
