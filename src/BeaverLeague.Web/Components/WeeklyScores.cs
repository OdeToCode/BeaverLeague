using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using BeaverLeague.Web.Components.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeaverLeague.Web.Components
{
    public class WeeklyScoresBase : ComponentBase
    {
        [Inject] public LeagueData leagueData { get; set; } = null!;
        [Inject] public IJSRuntime jsRuntime { get; set; } = null!;


        public Golfer? SelectedGolfer { get; set; }
        public IList<Golfer>? Golfers { get; private set; }

        public Func<Golfer, string> FormatGolfer { get; } = g =>
        {
            return $"{g.FirstName} {g.LastName}";
        };

        public Func<string, Func<Golfer, bool>> GolferFilter { get; } = s =>
        {
            return g => g.FirstName.Contains(s, StringComparison.CurrentCultureIgnoreCase) || g.LastName.Contains(s, StringComparison.CurrentCultureIgnoreCase);
        };

        protected bool Initialized { get; set; } = false;
        protected MatchSet? MatchSet { get; set; } = null;
        protected AddMatchModel? AddMatch { get; set; } = null;

        protected void NewMatch()
        {
            AddMatch = new AddMatchModel();
        }

        protected void UpdateGolferTwoPoints()
        {
            if (AddMatch == null) return;
            if (AddMatch.GolferOnePoints + AddMatch.GolferTwoPoints != 11.0m)
            {
                AddMatch.GolferTwoPoints = 11.0m - AddMatch.GolferOnePoints;
            }
        }

        protected void UpdateGolferOnePoints()
        {
            if (AddMatch == null) return;
            if (AddMatch.GolferOnePoints + AddMatch.GolferTwoPoints != 11.0m)
            {
                AddMatch.GolferOnePoints = 11.0m - AddMatch.GolferTwoPoints;
            }
        }

        protected void SaveMatch()
        {
            if (MatchSet != null)
            {
                var matchResult = new MatchResult();
                matchResult.MatchSetId = MatchSet.Id;
            }
            else
            {
                throw new InvalidOperationException($"{nameof(MatchSet)} is currently null");
            }
        }

        protected void CancelMatch()
        {
            AddMatch = null;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var weekId = await jsRuntime.InvokeAsync<int>("BeaverLeague.Components.WeeklyScores.weekId");
            MatchSet = leagueData.Execute(new MatchSetByIdQuery(weekId));
            Golfers = leagueData.Execute(new AllGolfersQuery(activeOnly: true, includeCardMatch: true))
                                .ToList();
            SelectedGolfer = Golfers.FirstOrDefault();
            Initialized = true;
        }
    }
}
