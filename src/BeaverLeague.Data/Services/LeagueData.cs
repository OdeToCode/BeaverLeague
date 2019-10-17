using BeaverLeague.Data.Queries;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Services
{
    public class LeagueData
    {
        private readonly LeagueDbContext db;

        public LeagueData(LeagueDbContext db)
        {
            this.db = db;
        }

        public TResult Execute<TSet, TResult>(IQuery<TSet, TResult> query) where TSet : class
        {
            if (query is null) throw new System.ArgumentNullException(nameof(query));

            var set = db.Set<TSet>();
            return query.Execute(set);
        }

        public void Add(object entity)
        {
            db.Add(entity);
        }

        public void Update(object entity)
        {
            var entityState = db.Entry(entity);
            entityState.State = EntityState.Modified;
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
