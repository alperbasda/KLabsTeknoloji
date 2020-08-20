using System;
using KLabs.Business.Abstract;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Service;
using KLabs.Entities.Enums;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Hizmetler")]
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("{name}/{id}")]
        public IActionResult Index(string name,Guid id)
        {
            var response = _serviceService.ServiceDetail(id);
            if (!response.Success) 
                return RedirectToAction("Index", "Home").Error(response.Message);
            FillServiceDetailImages((ServiceDetailPageModel)response.Data);
            return View(response.Data);
        }

        private void FillServiceDetailImages(ServiceDetailPageModel model)
        {
            model.Images=ImageConfig.FilePathsWithOutDots(new ImageOperationAdminModel
                { Id = model.Id, ImageType = ImageType.Service });

        }
    }
}
