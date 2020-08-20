using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Gizlilik")]
    public class PrivacyController : Controller
    {
        private IPrivacyService _privacyService;

        public PrivacyController(IPrivacyService privacyService, ICacheService cacheService)
        {
            _privacyService = privacyService;

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
            var response = _privacyService.GetPrivacy();
            if (response.Success)
                return View(response.Data);
            return RedirectToAction("Index", "Home").Error(response.Message);
        }
    }
}
