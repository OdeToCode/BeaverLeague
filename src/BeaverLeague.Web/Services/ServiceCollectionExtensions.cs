using System;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc()
               .AddRazorOptions(options =>
               {
                   options.ViewLocationFormats.Clear();
                   options.ViewLocationFormats.Add(@"Features\Shared\{0}.cshtml");
                   options.ViewLocationExpanders.Add(new ViewWithControllerViewLocationExpander());
               });

            return services;
        }
    }
}
