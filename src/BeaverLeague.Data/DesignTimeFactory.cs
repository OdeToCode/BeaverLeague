using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeaverLeague.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<LeagueDb>
    {
        public LeagueDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeagueDb>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BcccLeagueDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new LeagueDb(optionsBuilder.Options);
        }
    }
}
