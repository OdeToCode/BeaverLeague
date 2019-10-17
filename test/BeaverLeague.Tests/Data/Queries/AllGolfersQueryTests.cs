using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using System;
using System.Linq;
using Xunit;

namespace BeaverLeague.Tests.Data.Queries
{
    public class AllGolfersQueryTests : IDisposable
    {
        public AllGolfersQueryTests()
        {
            Db = new LeagueDbInstance(nameof(AllGolfersQueryTests));
            var context = Db.NewContext();

            context.Golfers.AddRange(
                new Golfer { Id = 1, FirstName = "A", IsActive = true },
                new Golfer { Id = 2, FirstName = "A", IsActive = true },
                new Golfer { Id = 3, FirstName = "B", IsActive = false },
                new Golfer { Id = 4, FirstName = "C", IsCardMatch = true }
            );
            context.SaveChanges();
        }

        public LeagueDbInstance Db { get; }

        [Fact]
        public void CanGetRealGolfersOnly()
        {
            var query = new AllGolfersQuery();
            var context = Db.NewContext();

            var result = query.Execute(context.Golfers).ToList();

            Assert.Equal(3, result.Count);
            Assert.Empty(result.Where(g => g.IsCardMatch == true));
        }

        [Fact]
        public void CanGetOnlyActiveWithCardMatch()
        {
            var query = new AllGolfersQuery(activeOnly: true, includeCardMatch : true);
            var context = Db.NewContext();

            var result = query.Execute(context.Golfers).ToList();

            Assert.Equal(3, result.Count);
            Assert.Empty(result.Where(g => g.IsActive == false));
        }

        [Fact]
        public void CanGetActiveWithNoCardMatch()
        {
            var query = new AllGolfersQuery(activeOnly:true);
            var context = Db.NewContext();

            var result = query.Execute(context.Golfers).ToList();

            Assert.Equal(2, result.Count);
            Assert.Empty(result.Where(g => g.IsActive == false));
            Assert.Empty(result.Where(g => g.IsCardMatch == true));
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
