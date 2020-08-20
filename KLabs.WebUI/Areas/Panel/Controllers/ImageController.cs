using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.Enums;
using KLabs.Entities.Responses;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Areas.Panel.Controllers
{

    [Area("Panel")]
    public class ImageController : Controller
    {
        public IActionResult ImageShowPartial(ImageOperationAdminModel model)
        {
            ViewData["Model"] = model;
            return PartialView("_ImageShowPartial", ImageConfig.FilePaths(model));
        }

        public IActionResult DeleteImage(string path)
        {
            return Json(ImageConfig.DeleteFile(path));
        }

        public async Task<IActionResult> AddImage(ImageOperationAdminModel model)
        {
            if (model.ImageType == ImageType.Logo || model.ImageType == ImageType.FavIcon)
                ImageConfig.DirectoryDelete(ImageConfig.Route(model));

            var response = new DataResponse();
            var files = GetImage();
            if (files.Count == 0)
                return Redirect(Request.Headers["Referer"].ToString());
            foreach (var file in files)
            {
                response = await ImageConfig.SaveFile(file, ImageConfig.Route(model));
                if (!response.Success)
                    return Json(response);
            }

            if (model.ImageType == ImageType.Logo || model.ImageType == ImageType.FavIcon)
                StaticMember.LogoPath = response.Data.ToString();

            return Json(response);
        }

        private IFormFileCollection GetImage()
        {
            return HttpContext.Request.Form.Files;

        }
    }
}
