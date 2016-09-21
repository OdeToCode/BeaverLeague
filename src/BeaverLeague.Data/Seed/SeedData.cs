using BeaverLeague.Core.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace BeaverLeague.Data.Seed
{
    public static class SeedData
    {
        public static void Seed(this LeagueDb db)
        {
            SeedGolfers(db);
        }

        private static void SeedGolfers(LeagueDb db)
        {

            if (!db.Golfers.Any())
            {
                var hasher = new PasswordHasher<Golfer>();
                var golfers = new[]
                {
                    new Golfer {FirstName = "Scott", LastName = "A", Handicap = 18, MembershipId = 5000, Username="sallen" },
                    new Golfer {FirstName = "Bobby", LastName = "S", Handicap = 14, MembershipId = 5001},
                    new Golfer {FirstName = "Jason", LastName = "N", Handicap = 12, MembershipId = 5002},
                    new Golfer {FirstName = "Jake", LastName = "M", Handicap = 14, MembershipId = 5003}
                };
                foreach (var golfer in golfers)
                {
                    golfer.PasswordHash = hasher.HashPassword(golfer, "123");
                    db.Add(golfer);
                }
                db.SaveChanges();
            }
        }
    }
}
