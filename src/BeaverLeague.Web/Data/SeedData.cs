using System.Linq;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Web.Security;

namespace BeaverLeague.Web.Data
{
    public static class SeedData
    {
        public static void Seed(this LeagueDb db)
        {
            SeedGolfers(db);
        }

        private static void SeedGolfers(LeagueDb db)
        {
            var hasher = new PasswordManager();
            if (!db.Golfers.Any())
            {
                var golfers = new[]
                {
                    new Golfer {FirstName = "Scott", EmailAddress="scott@server.com", LastName = "A", Handicap = 18, MembershipId = 5000, IsAdmin=true },
                    new Golfer {FirstName = "Bobby", EmailAddress="bobby@server.com", LastName = "S", Handicap = 14, MembershipId = 5001},
                    new Golfer {FirstName = "Jason", EmailAddress="jason@server.com", LastName = "N", Handicap = 12, MembershipId = 5002},
                    new Golfer {FirstName = "Jake",  EmailAddress="jake@server.com",  LastName = "M", Handicap = 14, MembershipId = 5003}
                };
                foreach (var golfer in golfers)
                {
                    hasher.SetPassword(golfer, "123");                  
                    db.Add(golfer);
                }
                db.SaveChanges();
            }
        }
    }
}