using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Features.Api.MatchSets
{
    public class MatchSetQuery : IRequest<MatchSet>
    {
        public int MatchSetId { get; set; }
    }

    public class MatchSetQueryHandler : IRequestHandler<MatchSetQuery, MatchSet>
    {
        private readonly LeagueDb _db;

        public MatchSetQueryHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<MatchSet> Handle(MatchSetQuery query, CancellationToken token)
        {
            return await _db.MatchSets
                    .Include(ms => ms.Matches)
                    .Include(ms => ms.Inactives)
                    .FirstAsync(ms => ms.Id == query.MatchSetId);
        }
    }
}