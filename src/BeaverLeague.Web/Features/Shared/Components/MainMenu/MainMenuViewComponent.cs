using Microsoft.AspNetCore.Mvc;

namespace BeaverLeague.Web.Features.MainMenu
{
    public class MainMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}