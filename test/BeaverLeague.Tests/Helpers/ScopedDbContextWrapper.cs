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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            scope.Dispose();
        }
    }
}