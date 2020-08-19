using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.Concrete;
using KLabs.Entities.Enums;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KLabs.WebUI.Areas.Panel.Controllers
{
    [Area("Panel")]
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

        public IActionResult CreateReference()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReference(Reference reference)
        {
            var response = _referenceService.AddReference(reference);
            if (response.Success)
                return RedirectToAction("Index", "Reference", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Reference", new { area = "Panel" }).Error(response.Message);
        }

        public IActionResult UpdateReference(Guid id)
        {
            var response = _referenceService.ReferenceById(id);
            if (response.Success)
                return View(response.Data);

            return RedirectToAction("Index", "Reference", new { area = "Panel" }).Error(response.Message);
        }

        [HttpPost]
        public IActionResult UpdateReference(Reference reference)
        {
            var response = _referenceService.UpdateReference(reference);
            if (response.Success)
                return RedirectToAction("Index", "Reference", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Reference", new { area = "Panel" }).Error(response.Message);
        }


        public IActionResult ReferenceSource(DataSourceLoadOptions options)
        {
            var response = _referenceService.ReferenceList(options);
            return Content(JsonConvert.SerializeObject(response.Data), "application/json");
        }

        public IActionResult DeleteReferenceJson(Guid id)
        {
            var response = _referenceService.DeleteReference(new Reference { Id = id });
            if (response.Success)
                DeleteReferenceImages(id);

            return Json(response);


        }


        private bool DeleteReferenceImages(Guid id)
        {
            return ImageConfig.DirectoryDelete(ImageConfig.Route(new ImageOperationAdminModel
            { Id = id, ImageType = ImageType.Reference }));
        }
    }
}
