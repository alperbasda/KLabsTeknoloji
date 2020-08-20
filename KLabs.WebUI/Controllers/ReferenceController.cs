using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Reference;
using KLabs.Entities.Enums;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KLabs.WebUI.Controllers
{
    [Route("Referans")]
    public class ReferenceController : Controller
    {
        private IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService,ICacheService cacheService)
        {
            _referenceService = referenceService;
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
            var response = _referenceService.HomePageReferences(0);
            if (!response.Success) 
                return RedirectToAction("Index", "Home").Error(response.Message);
            
            FillReferenceLogos((List<HomePageReferenceSwiperModel>)response.Data);
            return View(response.Data);

        }
        [Route("ReferansJson")]
        public IActionResult ReferenceJson(int page)
        {
            var response = _referenceService.HomePageReferences(page);
            if (!response.Success)
                return Json("");

            FillReferenceLogos((List<HomePageReferenceSwiperModel>)response.Data);
            return Json(response.Data);
        }

        private void FillReferenceLogos(List<HomePageReferenceSwiperModel> models)
        {
            foreach (var reference in models)
            {
                reference.LogoPath = ImageConfig.FileFirstPath(new ImageOperationAdminModel
                { Id = reference.Id, ImageType = ImageType.Reference }).ShowPath;
            }
        }

    }
}
