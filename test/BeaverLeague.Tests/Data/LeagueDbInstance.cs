using BeaverLeague.Data;
using System;

namespace BeaverLeague.Tests.Data
{
    public class LeagueDbInstance : DbInstance<LeagueDbContext>, IDisposable
    {
        public LeagueDbInstance(string name) : base(name, options => new LeagueDbContext(options))
        {
        }

        public void Dispose()
        {
            var db = NewContext();
            db.Database.EnsureDeleted();
        }
    }
}
