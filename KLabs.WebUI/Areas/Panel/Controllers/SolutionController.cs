using System;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
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
    public class SolutionController : Controller
    {
        private ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService, ICacheService cacheService)
        {
            _solutionService = solutionService;
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSolution()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSolution(Solution solution)
        {
            var response = _solutionService.AddSolution(solution);
            if (response.Success)
                return RedirectToAction("Index", "Solution", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Solution", new { area = "Panel" }).Error(response.Message);
        }

        public IActionResult UpdateSolution(Guid id)
        {
            var response = _solutionService.SolutionById(id);
            if (response.Success)
                return View(response.Data);

            return RedirectToAction("Index", "Solution", new { area = "Panel" }).Error(response.Message);
        }

        [HttpPost]
        public IActionResult UpdateSolution(Solution solution)
        {
            var response = _solutionService.UpdateSolution(solution);
            if (response.Success)
                return RedirectToAction("Index", "Solution", new { area = "Panel" }).Success(response.Message);

            return RedirectToAction("Index", "Solution", new { area = "Panel" }).Error(response.Message);
        }


        public IActionResult SolutionSource(DataSourceLoadOptions options)
        {
            var response = _solutionService.SolutionList(options);
            return Content(JsonConvert.SerializeObject(response.Data), "application/json");
        }

        public IActionResult DeleteSolutionJson(Guid id)
        {
            var response = _solutionService.DeleteSolution(new Solution { Id = id });
            if (response.Success)
                DeleteSolutionImages(id);

            return Json(response);


        }


        private void DeleteSolutionImages(Guid id)
        {
            ImageConfig.DirectoryDelete(ImageConfig.Route(new ImageOperationAdminModel
            { Id = id, ImageType = ImageType.Solution }));
        }
    }
}
