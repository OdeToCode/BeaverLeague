using System.Collections.Generic;
using BeaverLeague.Web.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Xunit;
using System.Reflection;
using BeaverLeague.Web.Features.Admin.ManageGolfers;
using static Xunit.Assert;

namespace BeaverLeague.Tests.Web.Services
{
    public class FeatureControllerModelConventionTests
    {       
        [Fact]
        public void CanBuildPathFromControllerNamespace()
        {
            var service = new FeatureControllerModelConvention();
            var controllerType = typeof(ManageGolfersController).GetTypeInfo();
            var attributes = new List<string>();
            var model = new ControllerModel(controllerType, attributes);

            service.Apply(model);

            Equal(@"Features\Admin\ManageGolfers", model.Properties["feature"]);
        }
    }
}
