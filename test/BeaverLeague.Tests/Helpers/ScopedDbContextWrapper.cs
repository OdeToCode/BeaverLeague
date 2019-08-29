using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BeaverLeague.Tests.Helpers
{
    public class ScopedDbContextWrapper<T> : IDisposable where T: DbContext 
    {
        private readonly IServiceScope scope;
        private readonly T db;

        public ScopedDbContextWrapper(IServiceProvider provider)
        {
            this.scope = provider.CreateScope();
            this.db = scope.ServiceProvider.GetRequiredService<T>();
        }

        public T Db => db;

        public virtual void Dispose()
        {
            this.scope.Dispose();
            this.db.Dispose();
        }
    }
}