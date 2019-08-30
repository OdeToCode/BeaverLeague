using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BeaverLeague.Tests.Helpers
{
    public class ScopedDbContextWrapper<T> : IDisposable where T: DbContext 
    {
        private readonly IServiceScope scope;

        public ScopedDbContextWrapper(IServiceProvider provider)
        {
            scope = provider.CreateScope();
            Db = scope.ServiceProvider.GetRequiredService<T>();
        }

        public T Db { get; }

        public virtual void Dispose()
        {
            scope.Dispose();
        }
    }
}