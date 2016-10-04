using BeaverLeague.Data;

namespace BeaverLeague.Tests.Data
{
    public class LeagueDbInstance : DbInstance<LeagueDb>
    {
        public LeagueDbInstance() : base(options => new LeagueDb(options))
        {
        }
    }
}
