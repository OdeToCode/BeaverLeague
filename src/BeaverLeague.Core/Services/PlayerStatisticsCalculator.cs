﻿using BeaverLeague.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverLeague.Core.Services
{
    public class PlayerStatisticsCalculator
    {
        public IList<PlayerStats> Calculate(IEnumerable<MatchSet> sets)
        {
            var stats = new List<PlayerStats>();

            foreach (var set in sets.OrderByDescending(s => s.Date))
            {
                foreach(var match in set.Matches)
                {
                    foreach(var player in match.Players)
                    {
                        AddResult(stats, player);
                    }
                }
            }

            Summarize(stats);

            return stats;
        }

        private void Summarize(List<PlayerStats> stats)
        {
            foreach(var entry in stats)
            {
                entry.TwelveBestPoints = entry.AllPoints.OrderBy(n => n).Take(12).Sum(n => n);
            }

            var rankedStats = stats.OrderBy(s => s.TwelveBestPoints)
                                   .ThenBy(s => s.LastPoints)
                                   .ThenBy(s => s.GrossScore)
                                   .Select((s, i) =>
                                   {
                                       s.Rank = i + 1;
                                       return s;
                                   });
        }

        private void AddResult(List<PlayerStats> stats, PlayerResult player)
        {
            var existing = stats.FirstOrDefault(s => s.GolferId == player.Golfer.Id);
            if(existing != null)
            {
                AddToExisting(existing, player);
            }
            else
            {
                CreateInitial(stats, player);
            }
        }

        private void AddToExisting(PlayerStats stats, PlayerResult player)
        {
            stats.AllScores.Add(player.Score);
            stats.AllPoints.Add(player.Points);
            stats.TotalRounds += 1;
        }

        private void CreateInitial(List<PlayerStats> stats, PlayerResult player)
        {
            var playerStats = new PlayerStats();
            playerStats.GolferId = player.Golfer.Id;
            playerStats.GrossScore = player.Score;
            playerStats.Handicap = player.Golfer.LeagueHandicap;
            playerStats.LastPoints = player.Points;
            playerStats.Name = $"{player.Golfer.FirstName} {player.Golfer.LastName[0]}.";
            playerStats.NetScore = player.Score - player.Golfer.LeagueHandicap;
            AddToExisting(playerStats, player);
        }
    }
}