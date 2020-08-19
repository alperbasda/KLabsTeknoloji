using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KLabs.WebUI.Controllers
{
    public class ReferenceController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
