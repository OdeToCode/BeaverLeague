using BeaverLeague.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeaverLeague.Data.Queries
{
    public class AllSeasonsQuery : IQuery<Season, IQueryable<Season>>
    {
        public IQueryable<Season> Execute(DbSet<Season> dbSet)
        {
            return dbSet.OrderByDescending(s => s.Id);            
        }
    }
}
