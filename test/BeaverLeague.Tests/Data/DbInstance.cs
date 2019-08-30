using System;
using Microsoft.EntityFrameworkCore;

namespace BeaverLeague.Tests.Data
{
    public class DbInstance<T> where T : DbContext
    {
        private readonly Func<DbContextOptions<T>, T> factory;

        public DbInstance(string name, Func<DbContextOptions<T>, T> factory)
        {
            Name = name;
            this.factory = factory;
        }

        public string Name { get; }

        public T NewContext()
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(Name)
                .Options;

            return factory(options);
        }
    }
}
