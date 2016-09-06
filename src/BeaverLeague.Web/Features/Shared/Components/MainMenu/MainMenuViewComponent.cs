using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.Shared.Components.MainMenu
{
    public class MainMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}