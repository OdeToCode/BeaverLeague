using System.Collections.Generic;
using System.Linq;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using MediatR;

namespace BeaverLeague.Web.Messaging.Golfers
{
    public class GolfersQuery : IRequest<List<Golfer>>
    {
        public GolfersQuery()
        {
            IsActive = false;   
        }

        public bool IsActive { get; set; }
    }

    public class GolfersQueryHandler : IRequestHandler<GolfersQuery, List<Golfer>>
    {
        private readonly LeagueDb _db;

        public GolfersQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public List<Golfer> Handle(GolfersQuery query)
        {
            return _db.Golfers
                      .Where(g => !query.IsActive || query.IsActive && g.IsActive)
                      .OrderBy(g => g.LastName).ToList();
        }
    }
}