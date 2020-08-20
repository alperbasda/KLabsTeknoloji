using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.AboutUs;
using KLabs.Entities.ComplexTypes.Image;
using KLabs.Entities.ComplexTypes.Service;
using KLabs.Entities.Enums;
using KLabs.WebUI.Helpers.ClaimHelper;
using KLabs.WebUI.Helpers.ImageHelper;
using KLabs.WebUI.Helpers.MailHelper;
using Microsoft.AspNetCore.Mvc;
using KLabs.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KLabs.WebUI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private SendMail _sendMail;
        public HomeController(ICacheService cacheService)
        {
            _sendMail = new SendMail();
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }

        }

        public IActionResult Index()
        {
            List<HomePageServiceModel> models = new List<HomePageServiceModel>();
            foreach (var service in StaticMember.MenuModels.Where(s => s.MenuType == MenuType.Service))
            {
                models.Add(new HomePageServiceModel
                {
                    Name = service.Name,
                    ImagePath = ImageConfig.FileFirstPath(new ImageOperationAdminModel
                    { Id = service.Id, ImageType = ImageType.ServiceHomePage }).ShowPath
                });
            }


            return View(models);
        }
        [Route("MailGonder")]
        [HttpPost]
        public async Task<IActionResult> SendMail(SendMailModel model)
        {
            if (!await CheckCaptcha())
            {
                TempData["Error"] = "Lütfen Ben Robot Değilim İşlemini Tamamlayın.";
                return RedirectToAction("ContactUs", "AboutUs", model);
            }

            if (ModelState.IsValid)
            {
                if (!_sendMail.MailGonder(model))
                {
                    TempData["Error"] = "Mail Gönderilirken Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyin.";
                    return RedirectToAction("ContactUs", "AboutUs", model);
                }

                TempData["Success"] = "Mailinize En Kısa Sürede Dönüş Yapılacaktır.";
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Mail Gönderilemedi.Lütfen Tüm Alanları Doldurun";

            return RedirectToAction("ContactUs", "AboutUs", model);
        }


        private async Task<bool> CheckCaptcha()
        {
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("secret", _sendMail.ReCaptcha),
                new KeyValuePair<string, string>("remoteip", HttpContext.Connection.RemoteIpAddress.ToString()),
                new KeyValuePair<string, string>("response", HttpContext.Request.Form["g-recaptcha-response"])
            };

            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));

            var o = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            return (bool)o["success"];
        }


    }
}
