using BeaverLeague.Data;
using BeaverLeague.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Tests.Pages
{
    public class BeaverLeagueWebFactory : WebApplicationFactory<Startup>
    {
        protected virtual string Name => nameof(BeaverLeagueWebFactory);

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<LeagueDbContext>(options =>
                {
                    options.UseInMemoryDatabase(Name);
                });
            });
        }

        public IServiceScope GetScope()
        {
            return Services.CreateScope();
        }

        public LeagueDbContext GetLeagueDbContext(IServiceScope scope)
        {
            return scope.ServiceProvider.GetService<LeagueDbContext>();
        }
    }
}
