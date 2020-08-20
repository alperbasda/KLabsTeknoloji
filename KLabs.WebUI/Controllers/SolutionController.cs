using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Solution;
using KLabs.Entities.Enums;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    [Route("Cozumler")]
    public class SolutionController : Controller
    {
        private ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService,ICacheService cacheService)
        {
            _solutionService = solutionService;
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }

        [Route("{name}/{id}")]
        public IActionResult Index(string name, Guid id)
        {
            var response = _solutionService.SolutionDetail(id);
            if (!response.Success)
                return RedirectToAction("Index", "Home").Error(response.Message);
            
            FillSolutionDetailImages((SolutionDetailPageModel) response.Data);
            return View(response.Data);

        }

        [Route("AnasayfaPartial")]
        public IActionResult HomePageSolutionsPartial(int page)
        {
            var response = _solutionService.HomePageSolutions(page);
            if (!response.Success)
                return PartialView("Error");


            FillSolutionImages((List<HomePageSolutionModel>)response.Data);
            return PartialView("Partials/_HomePageSolutionsPartial", response.Data);
        }

        private void FillSolutionImages(List<HomePageSolutionModel> models)
        {
            foreach (var solution in models)
            {
                solution.ImagePath = ImageConfig.FileFirstPath(new ImageOperationAdminModel
                { Id = solution.Id, ImageType = ImageType.SolutionHomePage }).ShowPath;
            }
        }

        private void FillSolutionDetailImages(SolutionDetailPageModel model)
        {
            model.Images=ImageConfig.FilePathsWithOutDots(new ImageOperationAdminModel
                { Id = model.Id, ImageType = ImageType.Solution });
            
        }
    }
}
