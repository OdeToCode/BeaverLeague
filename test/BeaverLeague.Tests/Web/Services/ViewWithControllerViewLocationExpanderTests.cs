using System.Linq;
using BeaverLeague.Web.Features.Home;
using BeaverLeague.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Xunit;
using static Xunit.Assert;
using System.Reflection;

namespace BeaverLeague.Tests.Web.Services
{
    public class ViewWithControllerViewLocationExpanderTests
    {
        [Fact]
        public void CanBuildPathFromControllerNamespace()
        {
            var service = new ViewWithControllerViewLocationExpander();
            var controllerContext = new ControllerContext
            {
                ActionDescriptor = new ControllerActionDescriptor()
                {
                    ControllerTypeInfo = typeof(HomeController).GetTypeInfo()
                }
            };           
            var expanderContext = new ViewLocationExpanderContext(controllerContext, "", "", "", false);

            var result = service.ExpandViewLocations(expanderContext, Enumerable.Empty<string>()).ToList();

            True(result.Count == 1, "Expand view locations should return 1 entry");
            Equal(@"Features\Home\{0}.cshtml", result[0]);
        }
    }
}
