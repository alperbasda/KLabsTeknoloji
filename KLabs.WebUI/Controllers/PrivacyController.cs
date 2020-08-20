using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.WebUI.Extensions.ControllerExtensions;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Gizlilik")]
    public class PrivacyController : Controller
    {
        private IPrivacyService _privacyService;

        public PrivacyController(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
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
