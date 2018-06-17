using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Enums;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Mvc;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ESD6NL.DriverSystem.Controllers
{
    public class RegistrationController : BaseController
    {
       

        public RegistrationController(IUserService regSerivce, ITranslationService ts) : base(ts,regSerivce)
        {
        }

        /// <summary>
        /// Display of the registration view
        /// </summary>
        /// <returns>Take a guess. Hint: It's not the login view</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// What do you think the Post function in a registration controller could possibly do?!
        /// </summary>
        /// <param name="model">Its a RegistrationModel. Take a wild guess</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(RegistrationModel model)
        {
            User toAdd = new User {email = model.Email, userName = model.Username, password = model.Password, firstName = model.FirstName, lastName = model.LastName, citizenServiceNumber = model.CitizenServiceNumber};
            if (_userService.createUser(toAdd) == null)
            {
                string language = Request.Cookies["Language"];
                string lang = Enum.Parse<Language>(language).ToString() ?? "NLD";
                if (lang.Equals("NLD"))
                {
                    ViewData["Error"] = "Er is een fout opgetreden bij het aanmaken van een gebruiker!";

                }
                else
                {
                    ViewData["Error"] = "Error in creating user, please check credentials!";
                }
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}