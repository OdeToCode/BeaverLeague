using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeaverLeague.Web.Services
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError("", error);
            }
        }
    }
}
