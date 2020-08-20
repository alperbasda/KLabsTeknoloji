using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Hakkimizda")]
    public class AboutUsController : Controller
    {
        public AboutUsController(ICacheService cacheService)
        {
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Iletisim")]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
