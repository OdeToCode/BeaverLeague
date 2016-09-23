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
            modelBuilder.Entity<Golfer>().HasIndex(g => g.EmailAdress).IsUnique();
        }

        public DbSet<Golfer> Golfers { get; set; }
    }
}
