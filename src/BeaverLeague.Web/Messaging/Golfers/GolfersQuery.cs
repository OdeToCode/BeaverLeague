using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using MediatR;

namespace BeaverLeague.Web.Messaging.Golfers
{
    public class GolfersQuery : IRequest<List<GolferSummary>>
    {
        public GolfersQuery()
        {
            IsActive = false;
        }

        public bool IsActive { get; set; }
    }

    public class GolferSummary
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public float Handicap { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }

    public class GolfersQueryHandler : IRequestHandler<GolfersQuery, List<GolferSummary>>
    {
        private readonly LeagueDb _db;

        public GolfersQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public Task<List<GolferSummary>> Handle(GolfersQuery query, CancellationToken cancel)
        {
            var golfers = 
                _db.Golfers
                      .Where(g => !query.IsActive || query.IsActive && g.IsActive)
                      .OrderBy(g => g.LastName)
                      .Select(g => new GolferSummary
                        {
                            Id = g.Id, FirstName = g.FirstName, Handicap = g.Handicap, IsActive = g.IsActive, IsAdmin = g.IsAdmin, LastName = g.LastName, MembershipId = g.MembershipId
                        })
                      .ToList();
            return Task.FromResult(golfers);
        }
    }
}