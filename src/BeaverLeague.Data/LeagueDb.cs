using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data
{
    public class LeagueDb : DbContext
    {        
        public LeagueDb(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Golfer>().HasIndex(g => g.MembershipId).IsUnique();
            modelBuilder.Entity<Golfer>().HasIndex(g => g.EmailAddress).IsUnique();
            modelBuilder.Entity<Season>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<MatchSet>().HasIndex(m => m.SeasonId);
            modelBuilder.Entity<MatchSetInactiveGolfer>().HasIndex(m => m.MatchSetId);
            modelBuilder.Entity<MatchSetInactiveGolfer>().HasOne<Golfer>();
        }

        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<MatchSet> MatchSets { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
