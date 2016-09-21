using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BeaverLeague.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityAndAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(options => options.SignInScheme = new IdentityCookieOptions().ExternalCookieAuthenticationScheme);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IdentityMarkerService>();
            services.TryAddScoped<IPasswordHasher<Golfer>, PasswordHasher<Golfer>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<Golfer>, UserClaimsPrincipalFactory<Golfer, GolferClaim>>();
            services.TryAddScoped<IUserStore<Golfer>, GolferStore>();
            services.TryAddScoped<IRoleStore<GolferClaim>, GolferClaimStore>();
            services.TryAddScoped<UserManager<Golfer>, UserManager<Golfer>>();
            services.TryAddScoped<SignInManager<Golfer>, SignInManager<Golfer>>();
            services.TryAddScoped<RoleManager<GolferClaim>, RoleManager<GolferClaim>>();            
            return services;
        }

        public static IServiceCollection AddDataStores(this IServiceCollection services,
                                                       string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LeagueDb>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            var expander = new FeatureViewLocationExpander();

            services.AddMvc(options =>
                {
                    options.Conventions.Add(new FeatureControllerModelConvention());
                })
               .AddRazorOptions(options =>
               {
                   options.ViewLocationFormats.Clear();
                   options.ViewLocationFormats.Add(@"{3}\{0}.cshtml");
                   options.ViewLocationFormats.Add(@"Features\Shared\{0}.cshtml");
                   options.ViewLocationExpanders.Add(expander);
               });

            return services;
        }
    }
}
