using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Reference;
using KLabs.Entities.Enums;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KLabs.WebUI.Controllers
{
    public class ReferenceController : Controller
    {
        private IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReferenceJson(int page)
        {
            var response = _referenceService.HomePageReferences(page);
            if (!response.Success)
                return Json("");

            FillReferenceLogos((List<HomePageReferenceSwiperModel>)response.Data);
            return Json(response.Data);
        }

        public void FillReferenceLogos(List<HomePageReferenceSwiperModel> models)
        {
            foreach (var reference in models)
            {
                reference.LogoPath = ImageConfig.FileFirstPath(new ImageOperationAdminModel
                    { Id = reference.Id, ImageType = ImageType.Reference }).ShowPath;
            }
        }

    }
}
