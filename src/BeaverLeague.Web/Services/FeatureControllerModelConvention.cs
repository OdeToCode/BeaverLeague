using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BeaverLeague.Web.Services
{
    public class FeatureControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var @namespace = controller.ControllerType.Namespace;
            var featureName = DeriveFeatureFolder(@namespace);
            controller.Properties.Add("feature", featureName);
        }

        private string DeriveFeatureFolder(string @namespace)
        {
            var result = @namespace?.Split('.')
                  .Skip(2)
                  .Aggregate("", Path.Combine);

            return result;
        }
    }
}
