using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Components
{
    public class LoadingViewComponent : ViewComponent
    {
        

        public IViewComponentResult Invoke(string id)
        {
            ViewData["Id"] = id;
            return View();
        }
    }
}