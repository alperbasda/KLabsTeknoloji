using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KLabs.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace KLabs.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
