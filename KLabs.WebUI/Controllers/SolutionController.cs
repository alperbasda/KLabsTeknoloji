using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Solution;
using KLabs.Entities.Enums;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Controllers
{
    public class SolutionController : Controller
    {
        private ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService)
        {
            _solutionService = solutionService;
        }

        public IActionResult Index(Guid id)
        {
            return View();
        }

        public IActionResult HomePageSolutionsPartial(int page)
        {
            var response = _solutionService.HomePageSolutions(page);
            if (!response.Success)
                return PartialView("Error");
            

            FillSolutionImages((List<HomePageSolutionModel>)response.Data);
            return PartialView("Partials/_HomePageSolutionsPartial",response.Data);
        }

        private void FillSolutionImages(List<HomePageSolutionModel> models)
        {
            foreach (var solution in models)
            {
              solution.ImagePath =  ImageConfig.FileFirstPath(new ImageOperationAdminModel
                    {Id = solution.Id, ImageType = ImageType.SolutionHomePage}).ShowPath;
            }
        }
    }
}
