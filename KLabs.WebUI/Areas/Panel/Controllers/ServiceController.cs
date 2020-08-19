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
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            var response = _serviceService.AddService(service);
            if (response.Success)
                return RedirectToAction("Index", "Service", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Service", new { area = "Panel" }).Error(response.Message);
        }

        public IActionResult UpdateService(Guid id)
        {
            var response = _serviceService.ServiceById(id);
            if (response.Success)
                return View(response.Data);

            return RedirectToAction("Index", "Service", new { area = "Panel" }).Error(response.Message);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            var response = _serviceService.UpdateService(service);
            if (response.Success)
                return RedirectToAction("Index", "Service", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Service", new { area = "Panel" }).Error(response.Message);
        }


        public IActionResult ServiceSource(DataSourceLoadOptions options)
        {
            var response = _serviceService.ServiceList(options);
            return Content(JsonConvert.SerializeObject(response.Data), "application/json");
        }

        public IActionResult DeleteServiceJson(Guid id)
        {
            var response = _serviceService.DeleteService(new Service { Id = id });
            if (response.Success)
                DeleteServiceImages(id);

            return Json(response);


        }


        private void DeleteServiceImages(Guid id)
        {
            ImageConfig.DirectoryDelete(ImageConfig.Route(new ImageOperationAdminModel
            { Id = id, ImageType = ImageType.Service }));
        }
    }
}
