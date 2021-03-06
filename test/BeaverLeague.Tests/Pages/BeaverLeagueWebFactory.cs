﻿using BeaverLeague.Core.Services;
using BeaverLeague.Data;
using BeaverLeague.Tests.Helpers;
using BeaverLeague.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BeaverLeague.Tests.Pages
{
    public class BeaverLeagueWebFactory : WebApplicationFactory<Startup>
    {
        public string Name { get; } = Guid.NewGuid().ToString();

        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                       .UseEnvironment("IntegrationTests");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));
            
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemClock, FixedClock>();
                services.AddDbContextPool<LeagueDbContext>(options =>
                {
                    options.UseInMemoryDatabase(Name);
                });
            });
        }

        protected override void Dispose(bool disposing)
        {
            using var scope = Services.GetScopedDbContext<LeagueDbContext>();
            scope.Db.Database.EnsureDeleted();
        }
    }
}
