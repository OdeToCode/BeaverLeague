using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Linq;

namespace BeaverLeague.Web.Services
{
    public class ViewWithControllerViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context, 
            IEnumerable<string> viewLocations)
        {
            var controllerDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
            var @namespace = controllerDescriptor?.ControllerTypeInfo?.Namespace;
            if (@namespace != null)
            {
                var result = @namespace.Split('.')
                    .Skip(2)
                    .Aggregate("",
                        Path.Combine,
                        path => Path.Combine(path, "{0}.cshtml"));

                yield return result;
            }

            foreach (var location in viewLocations)
            {
                yield return location;
            }
        }
    }
}