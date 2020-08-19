using System;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
