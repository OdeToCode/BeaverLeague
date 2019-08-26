using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data
{
    public class LeagueDbContext : DbContext
    {        
        public LeagueDbContext(DbContextOptions options) : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Golfer>()
                        .HasIndex(g => g.EmailAddress)
                        .IsUnique();
        }

        public DbSet<Golfer> Golfers { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
    }
}
