using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeaverLeague.Core.Models
{
    public class Golfer
    {
        public int Id { get; set; }

        [Display(Name = "MSGA Handicap"), Range(-36, 36)]
        public int LeagueHandicap { get; set; } = 18;

        [Display(Name ="Active")]
        public bool IsActive { get; set; }

        [MaxLength(80), Required, Display(Name ="First Name")]
        public string FirstName { get; set; } = "";

        [MaxLength(80), Required, Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        [MaxLength(80), Display(Name ="Email"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [MaxLength(80), Required, Display(Name ="Phone"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";

        public TeeType Tee { get; set; } = TeeType.White;

    }

    public enum TeeType
    {
        Blue, 
        White,
        Green,
        Gold,
        Black,
        Red,
        SeniorRed
    }

    public class MatchResult
    {
        public int Id { get; set; }
        public MatchPlayer PlayerA { get; set; }
        public MatchPlayer PlayerB { get; set; }
    }

    public class MatchPlayer
    {
        public int Id { get; set; }
        public int GolferId { get; set; }
        public int Score { get; set; }
        public int Strokes { get; set; }
        public bool PlayNextWeek { get; set; }
        public decimal Points { get; set; }

    }

    public class MatchSet
    {
        public MatchSet(DateTime date)
        {
            Date = date;
            Matches = new HashSet<MatchResult>();
        }

        public int Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public ICollection<MatchResult> Matches { get; protected set; }

        public MatchResult NewMatchResult(Golfer playerA, int playerAScore, decimal playerAPoints, bool playerANextWeek, 
                                          Golfer playerB, int PlayerBScore, decimal playerBPoints, bool playerBNextWeek)
        {
            var match = new MatchResult();
            match.PlayerA = NewMatchPlayer(playerA, playerAScore, playerAPoints, playerANextWeek);
            match.PlayerB = NewMatchPlayer(playerB, PlayerBScore, playerBPoints, playerBNextWeek);
            Matches.Add(match);
            return match;

        }

        protected MatchPlayer NewMatchPlayer(Golfer golfer, int score, decimal points, bool playNextWeek)
        {
            var matchPlayer = new MatchPlayer
            {
                GolferId = golfer.Id,
                PlayNextWeek = playNextWeek,
                Score = score,
                Strokes = golfer.LeagueHandicap,
                Points = points
            };

            return matchPlayer;
        }
    }

    public class Season
    {
        public Season(string name)
        {
            Name = name;
            Weeks = new HashSet<MatchSet>();
        }

        [Required, MaxLength(80)]
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<MatchSet> Weeks   { get; set; }

        public MatchSet NewWeek(DateTime date)
        {
            var set = new MatchSet(date);
            Weeks.Add(set);
            return set;
        }
    }
}
