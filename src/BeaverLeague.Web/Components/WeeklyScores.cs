using BeaverLeague.Core.Models;
using BeaverLeague.Data.Queries;
using BeaverLeague.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeaverLeague.Web.Components
{
    public class MatchSetEditModel : IValidatableObject
    {
        [Required]
        public Golfer? GolferA { get; set; }
        
        [Range(1, 100)]
        public int ScoreA { get; set; }
        
        [Range(0, 11)]
        public decimal PointsA { get; set; }
        public bool PlayAgainA { get; set; }

        [Required]
        public Golfer? GolferB { get; set; }
        
        [Range(1,100)]
        public int ScoreB { get; set; }
        
        [Range(0,11)]
        public decimal PointsB { get; set; }

        public bool PlayAgainB { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(PointsA + PointsB != 11.0m)
            {
                yield return new ValidationResult("Match points must add up to 11");
            }
        }
    }


    public class WeeklyScoresBase : ComponentBase
    {
        [Inject] public LeagueData leagueData { get; set; } = null!;
        [Inject] public IJSRuntime jsRuntime { get; set; } = null!;

        public MatchSet? MatchSet { get; private set; }
        public Dictionary<string, Golfer>? Golfers { get; private set; }
        public MatchSetEditModel? EditModel { get; set; }
        public int WeekId { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            WeekId = await jsRuntime.InvokeAsync<int>("BeaverLeague.Components.WeeklyScores.weekId");
            RefreshData();
        }

        private void RefreshData()
        {
            MatchSet = leagueData.Execute(new MatchSetByIdQuery(WeekId));

            var golfersIn = MatchSet.Matches
                                    .SelectMany(m => m.Players)
                                    .Select(r => r.Golfer);

            Golfers = leagueData.Execute(new AllGolfersQuery(activeOnly: true, includeCardMatch: true))
                                .AsEnumerable()
                                .Where(g => !golfersIn.Contains(g))
                                .ToDictionary(g => $"{g.FirstName} {g.LastName}");
        }

        protected string ComputeBackground(MatchResult result, int player)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            
            var thisOne = result.Players[player];
            var otherOne = player == 0 ? result.Players[1] : result.Players[0];

            if (thisOne.Points > otherOne.Points)
            {
                return "fas fa-medal text-success";
            }
            return "";
        }

        protected void AddNewMatch()
        {
            EditModel = new MatchSetEditModel();
        }

        protected void UpdateGolferBPoints()
        {
            if (EditModel == null) return;
            if (EditModel.PointsA + EditModel.PointsB != 11.0m)
            {
                EditModel.PointsB = 11.0m - EditModel.PointsA;
            }
        }

        protected void UpdateGolferAPoints()
        {
            if (EditModel == null) return;
            if (EditModel.PointsA + EditModel.PointsB != 11.0m)
            {
                EditModel.PointsA = 11.0m - EditModel.PointsB;
            }
        }

        protected void CancelMatch()
        {
            EditModel = null;
        }

        protected void SaveMatch()
        {
            if (MatchSet == null) throw new InvalidOperationException($"{nameof(MatchSet)} cannot be null");
            if (EditModel == null) throw new InvalidOperationException($"{nameof(EditModel)} cannot be null");
            if (EditModel.GolferA == null) throw new InvalidOperationException($"{nameof(EditModel.GolferA)} cannot be null");
            if (EditModel.GolferB == null) throw new InvalidOperationException($"{nameof(EditModel.GolferB)} cannot be null");

            var match = MatchSet.AddResult(EditModel.GolferA, EditModel.ScoreA, EditModel.PointsA, EditModel.PlayAgainA,
                                           EditModel.GolferB, EditModel.ScoreB, EditModel.PointsB, EditModel.PlayAgainB);

            leagueData.Add(match);
            leagueData.Commit();
            RefreshData();

            EditModel = null;
        }
    }
}
