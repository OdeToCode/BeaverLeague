using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using BeaverLeague.Web.Components.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BeaverLeague.Web.Components
{
    public class WeeklyScoresBase : ComponentBase
    {
        [Inject] public LeagueData leagueData { get; set; } = null!;
        [Inject] public IJSRuntime jsRuntime { get; set; } = null!;

        protected bool initialized = false;
        protected MatchSet? matchSet = null;
        protected AddMatchModel? addMatch = null;

        protected void NewMatch()
        {
            addMatch = new AddMatchModel();
        }

        protected void SaveMatch()
        {
            var matchResult = new MatchResult();
            matchResult.MatchSetId = matchSet.Id;
        }

        protected void CancelMatch()
        {
            addMatch = null;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var weekId = await jsRuntime.InvokeAsync<int>("BeaverLeague.Components.WeeklyScores.weekId");
            matchSet = leagueData.Execute(new MatchSetByIdQuery(weekId));

            initialized = true;
        }
    }
}
