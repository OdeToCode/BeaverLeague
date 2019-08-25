using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
            var season = db.Seasons
                           .Include(s => s.Weeks)
                           .ThenInclude(m => m.Matches)
                           .First();
            return season;
        }

        public IQueryable<Golfer> GetAllGolfers()
        {
            var result = db.Golfers
                           .OrderByDescending(g => g.IsActive)
                           .ThenBy(g => g.LastName)
                           .ThenBy(g => g.FirstName);
            return result;
        }

        public void Add(object entity)
        {
            db.Add(entity);
        }

        public void Add(params object[] entities)
        {
            foreach(var entity in entities)
            {
                Add(entity);
            }
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
