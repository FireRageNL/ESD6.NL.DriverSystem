using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ESD6NL.DriverSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService _userService;

        public HomeController(IUserService userService, ITranslationService ts) : base(ts)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("User"))
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel login)
        {
            if (!ModelState.IsValid || !_userService.checkUserLogin(login.Password, login.Username)) return View(login);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "User"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            Response.Cookies.Append("Language",_userService.getserByUsername(login.Username).Language);
            return RedirectToAction("Home","Home");

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }
    }
}
