using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.Concrete;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class AboutUsController : Controller
    {
        private IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService,ICacheService cacheService)
        {
            _aboutUsService = aboutUsService;
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }

        public IActionResult Index()
        {
            var response = _aboutUsService.GetAboutUs();
            if (response.Success)
                return View(response.Data);
            return RedirectToAction("Index", "Home", new {area = "Panel"}).Error(response.Message);
        }

        [HttpPost]
        public IActionResult UpdateAboutUs(AboutUs aboutUs)
        {
            var response =  _aboutUsService.UpdateAboutUs(aboutUs);
            if (response.Success)
                return RedirectToAction("Index", "AboutUs", new {area = "Panel"}).Success(response.Message);

            return RedirectToAction("Index", "AboutUs", new { area = "Panel" }).Error(response.Message);
        }
    }
}
