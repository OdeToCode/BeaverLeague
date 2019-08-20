using BeaverLeague.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeaverLeague.Data.Services
{
    public class LeagueData
    {
        private readonly LeagueDbContext db;

        public LeagueData(LeagueDbContext db)
        {
            this.db = db;
        }

        public Season GetCurrentSeason()
        {
            var season = db.Seasons.OrderByDescending(s => s.Id).First();
            return season;
        }

        public void Add<T>(T entity)
        {
            db.Add(entity);
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
