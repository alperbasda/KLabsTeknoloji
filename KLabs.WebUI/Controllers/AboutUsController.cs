using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Hakkimizda")]
    public class AboutUsController : Controller
    {
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
