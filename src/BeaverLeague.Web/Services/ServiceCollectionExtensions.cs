using System;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            var locationFormat = @"Features\Shared\{0}.cshtml";
            var expander = new ViewWithControllerViewLocationExpander();

            services.AddMvc()
               .AddRazorOptions(options =>
               {
                   options.ViewLocationFormats.Clear();
                   options.ViewLocationFormats.Add(locationFormat);
                   options.ViewLocationExpanders.Add(expander);
               });

            return services;
        }
    }
}
