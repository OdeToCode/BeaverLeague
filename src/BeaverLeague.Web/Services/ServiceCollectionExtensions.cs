using System;
using Microsoft.Extensions.DependencyInjection;

namespace BeaverLeague.Web.Services
{
    public static class ServiceCollectionExtensions
    {
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
