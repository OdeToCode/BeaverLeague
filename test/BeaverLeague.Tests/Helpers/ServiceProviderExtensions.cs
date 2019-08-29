using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeaverLeague.Tests.Helpers
{
    public static class ServiceProviderExtensions
    {
        public static ScopedDbContextWrapper<T> GetScopedDbContext<T>(this IServiceProvider provider)
            where T: DbContext
        {
            return new ScopedDbContextWrapper<T>(provider);
        }   
    }
}
