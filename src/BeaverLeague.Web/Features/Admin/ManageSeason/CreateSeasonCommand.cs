using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Web.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Web.Features.Admin.ManageSeason
{
    public class CreateSeasonCommand : IRequest<CreateSeasonResult>
    {
        [Required, MaxLength(80)] 
        public string Name { get; set; }                              
    }

    public class CreateSeasonResult : CommandResult
    {
        public Season NewSeason { get; set; }
    }

    public class CreateSeasonCommandHandler : IRequestHandler<CreateSeasonCommand, CreateSeasonResult>
    {
        private readonly LeagueDb _db;

        public CreateSeasonCommandHandler(LeagueDb db)
        {
            _db = db;
        }

        public async Task<CreateSeasonResult> Handle(CreateSeasonCommand message, CancellationToken cancel)
        {
            var result = new CreateSeasonResult();
            await ValidateSeason(message, result);
            if (result.Errors.Count < 1)
            {
                result.NewSeason = new Season {Name = message.Name, IsCurrent=true };
                _db.Seasons.Add(result.NewSeason);
                await _db.SaveChangesAsync();
            }
            return result;
        }

        private async Task ValidateSeason(CreateSeasonCommand message, CreateSeasonResult result)
        {
            var seasonWithSameName = await _db.Seasons.FirstOrDefaultAsync(s => s.Name == message.Name);
            if (seasonWithSameName != null)
            {
                result.Errors.Add("Season name is not unique! Choose a different name.");
            }

            var currentSeason = await _db.Seasons.FirstOrDefaultAsync(s => s.IsCurrent);
            if (currentSeason != null)
            {
                result.Errors.Add("There is already a current season. Mark the current season as closed and then try this again.");
            }
        }
    }
}

