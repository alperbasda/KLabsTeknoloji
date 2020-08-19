using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.Enums;
using KLabs.Entities.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace KLabs.WebUI.Helpers.ImageHelper
{
    public static class ImageConfig
    {
        private static string _rootBase = "wwwroot/images";

        public static string ReferencePath => "Reference";

        public static string SolutionPath => "Solution";

        public static string ServicePath => "Service";

        public static string ServiceHomePagePath => "ServiceHome";

        public static string SolutionHomePagePath => "SolutionHome";

        public static string LogoPath => "Service";

        public static void CreateBaseDirectories()
        {
            DirectoryCreate(Path.Combine(_rootBase, ReferencePath));
            DirectoryCreate(Path.Combine(_rootBase, SolutionPath));
            DirectoryCreate(Path.Combine(_rootBase, SolutionHomePagePath));
            DirectoryCreate(Path.Combine(_rootBase, ServicePath));
            DirectoryCreate(Path.Combine(_rootBase, ServiceHomePagePath));
            DirectoryCreate(Path.Combine(_rootBase, LogoPath));

        }

        public static bool DirectoryCreate(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool DirectoryDelete(string path)
        {
            
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (Exception e)
                {
                    return false;
                }

            }

            return true;
        }

        public static async Task<DataResponse> SaveFile(IFormFile file, string path)
        {
            try
            {

                DirectoryCreate(path);
                path = Path.Combine(path, file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return new DataResponse
                {
                    Success = true,
                    Message = "Resim(ler) Kayıt Edildi",
                    Data = $"../{path.Replace("wwwroot/", "").Replace('\\', '/')}"
                };
            }
            catch (Exception ex)
            {
                return new DataResponse
                {
                    Success = false,
                    Message = "Resim(ler) Silinirken Hata Oluştu"
                };
            }
        }

        public static List<ImageShowModel> FilePaths(ImageOperationAdminModel model)
        {
            var path = Route(model);
            var imageList = new List<ImageShowModel>();
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    imageList.Add(new ImageShowModel
                    {
                        Id = model.Id,
                        ImageType = model.ImageType,
                        ShowPath = $"../{file.Replace("wwwroot/", "").Replace('\\', '/')}",
                        DeletePath = file
                    });
                }
    
            }
                

            return imageList;
        }

        public static ImageShowModel FileFirstPath(ImageOperationAdminModel model)
        {
            var path = Route(model);
            
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                {

                    return new ImageShowModel
                    {
                        Id = model.Id,
                        ImageType = model.ImageType,
                        ShowPath = $"../{file.Replace("wwwroot/", "").Replace('\\','/')}",
                        DeletePath = file
                    };
                }
            }


            return new ImageShowModel
            {
                Id = model.Id,
                ImageType = model.ImageType,
                ShowPath = GetLogoPath()
            };
        }

        public static DataResponse DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                return new DataResponse
                {
                    Success = true,
                    Message = "Resim Silindi"
                };
            }
            catch (Exception ex)
            {
                return new DataResponse
                {
                    Success = false,
                    Message = "Resim Silinirken Hata Oluştu"
                };
            }

        }



        public static string Route(ImageOperationAdminModel model)
        {
            return Path.Combine(_rootBase, model.ImageType.ToString(), model.Id.ToString());
        }

        public static string RouteFile(ImageOperationAdminModel model,string fileName)
        {
            return Path.Combine(_rootBase, model.ImageType.ToString(), model.Id.ToString(),fileName);
        }

        public static string GetLogoPath()
        {
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                var files = FilePaths(new ImageOperationAdminModel
                    { Id = Guid.Empty, ImageType = ImageType.Logo });
                StaticMember.LogoPath = $"../{files.First().ShowPath}";
            }
            
            return StaticMember.LogoPath;
        }

    }
}