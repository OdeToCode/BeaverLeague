using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BeaverLeague.Data
{
    /// <summary>
    /// This class only exists to use LeagueDb by executing this assembly 
    /// as an application for migrations and seeding data. 
    /// </summary>
    public class LeagueDbFactory : IDbContextFactory<LeagueDb>
    {
        public LeagueDb Create(DbContextFactoryOptions options)
        {         
            var builder = new DbContextOptionsBuilder<LeagueDb>();
            builder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=BcccLeagueDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new LeagueDb(builder.Options);
        }
    }
}
