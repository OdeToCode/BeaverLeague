using System.Collections.Generic;
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
        public void CanFindFeature()
        {
            var expectedFeature = "testfeature";
            var service = new FeatureViewLocationExpander();
            var controllerContext = new ControllerContext
            {
                ActionDescriptor = new ControllerActionDescriptor()
                {
                    ControllerTypeInfo = typeof(HomeController).GetTypeInfo(),
                    Properties = { { "feature", expectedFeature} }
                }
            };           
            var expanderContext = new ViewLocationExpanderContext(controllerContext, "", "", "", "", false);
            var viewLocations = new List<string> {@"{3}\{0}.cshtml"};

            var result = service.ExpandViewLocations(expanderContext, viewLocations).ToList();

            True(result.Count == 1, "Expand view locations should return 1 entry");
            Equal($"{expectedFeature}\\{{0}}.cshtml", result[0]);
        }
    }
}
