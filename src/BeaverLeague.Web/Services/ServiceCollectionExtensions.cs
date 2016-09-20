using System;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using Microsoft.AspNetCore.Authentication;
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
            //services.TryAddScoped<IUserValidator<TUser>, UserValidator<TUser>>();
            //services.TryAddScoped<IPasswordValidator<TUser>, PasswordValidator<TUser>>();
            //services.TryAddScoped<IPasswordHasher<TUser>, PasswordHasher<TUser>>();
            //services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            //services.TryAddScoped<IRoleValidator<TRole>, RoleValidator<TRole>>();
            //services.TryAddScoped<IdentityErrorDescriber>();
            //services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<TUser>>();
            //services.TryAddScoped<IUserClaimsPrincipalFactory<TUser>, UserClaimsPrincipalFactory<TUser, TRole>>();
            //services.TryAddScoped<UserManager<TUser>, UserManager<TUser>>();
            //services.TryAddScoped<SignInManager<TUser>, SignInManager<TUser>>();
            //services.TryAddScoped<RoleManager<TRole>, RoleManager<TRole>>();
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("isAdmin", policy =>
            //    {
            //        policy.RequireClaim("isAdmin");
            //    });
            //});

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
