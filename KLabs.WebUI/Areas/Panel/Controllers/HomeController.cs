using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class HomeController : Controller
    {
        public HomeController(ICacheService cacheService)
        {
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
