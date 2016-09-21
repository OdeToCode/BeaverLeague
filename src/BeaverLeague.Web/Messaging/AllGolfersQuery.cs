using System.Collections.Generic;
using System.Linq;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using MediatR;

namespace BeaverLeague.Web.Features.Admin.ManageGolfers
{
    public class AllGolfersQuery : IRequest<List<Golfer>>
    {

    }

    public class AllGolfersQueryHandler : IRequestHandler<AllGolfersQuery, List<Golfer>>
    {
        private readonly LeagueDb _db;

        public AllGolfersQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public List<Golfer> Handle(AllGolfersQuery message)
        {
            return _db.Golfers.OrderBy(g => g.LastName).ToList();
        }
    }
}