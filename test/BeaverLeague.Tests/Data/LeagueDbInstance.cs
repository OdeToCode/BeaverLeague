using BeaverLeague.Data;

namespace BeaverLeague.Tests.Data
{
    public class LeagueDbInstance : DbInstance<LeagueDbContext>
    {
        public LeagueDbInstance(string name) : base(name, options => new LeagueDbContext(options))
        {
        }
    }
}
