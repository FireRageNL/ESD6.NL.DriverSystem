using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ESD6NL.DriverSystem.Controllers
{
    public class BaseController : Controller
    {
        private static ITranslationService ts;

        public IUserService _userService;

        public BaseController(ITranslationService ts, IUserService us)
        {
            TranslationHelper.setService(ts);
            _userService = us;
        }

        public User getUser()
        {
            string username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return _userService.getUserByUsername(username);
        }
    }
}