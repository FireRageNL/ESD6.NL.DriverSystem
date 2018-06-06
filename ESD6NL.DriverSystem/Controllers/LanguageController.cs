using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Enums;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace ESD6NL.DriverSystem.Controllers
{
    public class LanguageController: Controller
    {
        private IUserService _service;

        public LanguageController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ChangeLanguage(string language)
        {
            string username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            Entities.User usr = _service.getUserByUsername(username);
            string lang = Enum.Parse<Language>(language).ToString() ?? "NLD";
            if (usr != null)
            {
                usr.Language = lang;
                _service.saveUser(usr);
            }
            Response.Cookies.Append("Language", lang);
            return Redirect(Request.Headers["Referer"]);
        }
    }
}
