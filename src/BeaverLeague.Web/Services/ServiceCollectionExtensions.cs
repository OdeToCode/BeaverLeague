using BeaverLeague.Data;
using BeaverLeague.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web.Services
{
    public static class ServiceCollectionExtensions
    {        
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddAuthorization(options => new AuthorizationPolicies(options).Apply());

            services.AddTransient<SignInManager>();
            services.AddTransient<PasswordManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

        public static IServiceCollection AddDataStores(this IServiceCollection services,
                                                       IConfiguration configuration)
        {
            services.AddDbContext<LeagueDb>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(nameof(LeagueDb)));
                });

            return services;
        }
    }
}
