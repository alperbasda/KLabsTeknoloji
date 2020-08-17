using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
