using BeaverLeague.Data;

namespace BeaverLeague.Tests.Data
{
    public class LeagueDbInstance : DbInstance<LeagueDb>
    {
        public LeagueDbInstance(string name) : base(name, options => new LeagueDb(options))
        {
        }
    }
}
