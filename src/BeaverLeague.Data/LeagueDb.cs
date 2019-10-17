using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeaverLeague.Data
{
    public class LeagueDbContext : DbContext
    {        
        public LeagueDbContext(DbContextOptions options) : base(options)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Golfer>()
                        .HasIndex(g => g.EmailAddress)
                        .IsUnique();
        }

        public DbSet<Golfer> Golfers { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
        public DbSet<MatchSet> MatchSets { get; set; } = null!;
    }
}
