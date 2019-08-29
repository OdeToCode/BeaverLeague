using Microsoft.EntityFrameworkCore;
using System;

namespace BeaverLeague.Tests.Helpers
{
    public class DeletingDbContextWrapper<T> : ScopedDbContextWrapper<T> where T : DbContext
    {
        public DeletingDbContextWrapper(IServiceProvider provider) : base(provider)
        {
        }

        public override void Dispose()
        {
            this.Db.Database.EnsureDeleted();
        }
    }
}
