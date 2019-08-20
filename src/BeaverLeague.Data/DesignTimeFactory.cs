using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeaverLeague.Data
{
    public class LeagueDbContextDesignTimeFactory : IDesignTimeDbContextFactory<LeagueDbContext>
    {
        public LeagueDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeagueDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BcccLeagueDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new LeagueDbContext(optionsBuilder.Options);
        }
    }
}
