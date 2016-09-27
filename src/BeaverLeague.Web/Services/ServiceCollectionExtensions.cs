using BeaverLeague.Data;
using BeaverLeague.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
