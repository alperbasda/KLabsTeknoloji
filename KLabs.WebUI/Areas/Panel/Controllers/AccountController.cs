using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes.User;
using KLabs.Entities.Concrete;
using KLabs.WebUI.Extensions.ControllerExtensions;
using KLabs.WebUI.Helpers.ClaimHelper;
using KLabs.WebUI.Helpers.ImageHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KLabs.WebUI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService,ICacheService cacheService)
        {
            _userService = userService;
            if (string.IsNullOrEmpty(StaticMember.LogoPath))
            {
                cacheService.FillData();
                ImageConfig.GetLogoPath();
                ImageConfig.GetFavPath();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(PostUserLoginModel model)
        {
            var userToLogin = _userService.Login(model);
            if (!userToLogin.Success)
            {
                return View().Error(userToLogin.Message);
            }

            await LoginUser((User)userToLogin.Data);

            TempData["Success"] = userToLogin.Message;
            return RedirectToAction("Index", "Home", new { area = "Panel" });
        }



        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account", new { area = "Panel" }).Success("Çıkış Yapıldı.");
        }

        //[HttpPost]
        //public ActionResult CreateUser(PostUserRegisterModel model)
        //{
        //    var response = _userService.Register(model);
        //    if (response.Success)
        //        return RedirectToAction("Index", "Home", new {area = "Panel"}).Success(response.Message);

        //    return RedirectToAction("Login", "Account", new { area = "Panel" }).Error(response.Message);
        //}

        private async Task LoginUser(User user)
        {
            var claims = ClaimHelper.ClaimFromUser(user,
                _userService.GetClaims(user).Select(w => w.Name).ToList());

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}
