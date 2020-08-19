﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.Concrete;
using KLabs.WebUI.Extensions.ControllerExtensions;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class PrivacyController : Controller
    {
        private IPrivacyService _privacyService;

        public PrivacyController(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
        }

        public IActionResult Index()
        {
            var response = _privacyService.GetPrivacy();
            if (response.Success)
                return View(response.Data);
            return RedirectToAction("Index", "Home", new { area = "Panel" }).Error(response.Message);
        }

        [HttpPost]
        public IActionResult UpdatePrivacy(Privacy privacy)
        {
            var response = _privacyService.UpdatePrivacy(privacy);
            if (response.Success)
                return RedirectToAction("Index", "Privacy", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Privacy", new { area = "Panel" }).Error(response.Message);
        }
    }
}