using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data
{
    public class LeagueDb : DbContext
    {        
        public LeagueDb(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Golfer> Golfers { get; set; }
    }
}
