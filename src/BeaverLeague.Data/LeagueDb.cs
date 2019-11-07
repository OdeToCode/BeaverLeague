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
            
            BuildModel(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Golfer>()
                        .HasData(new Golfer
                        {
                            Id = -1,
                            FirstName = "Card",
                            LastName = "Match",
                            IsActive = false,
                            IsCardMatch = true
                        });

        }

        private void BuildModel(ModelBuilder modelBuilder)
        {
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
