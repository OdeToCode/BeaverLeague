using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Data.Queries
{
    public interface IQuery<TSet, TResult> where TSet : class
    {
        TResult Execute(DbSet<TSet> dbSet);
    }
}
