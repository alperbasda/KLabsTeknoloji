using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Service;
using KLabs.Entities.Enums;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;
using KLabs.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace KLabs.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICacheService cacheService)
        {
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
            }
                
        }

        public IActionResult Index()
        {
            List<HomePageServiceModel> models = new List<HomePageServiceModel>();
            foreach (var service in StaticMember.MenuModels.Where(s=>s.MenuType==MenuType.Service))
            {
                models.Add(new HomePageServiceModel
                {
                    Name = service.Name,
                    ImagePath = ImageConfig.FileFirstPath(new ImageOperationAdminModel
                        {Id = service.Id, ImageType = ImageType.ServiceHomePage}).ShowPath
                });
            }


            return View(models);
        }


    }
}
