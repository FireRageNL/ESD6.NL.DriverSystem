using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Mvc;
using ESD6NL.DriverSystem.Entities;
using Microsoft.AspNetCore.Identity;

namespace ESD6NL.DriverSystem.Controllers
{
    public class RegistrationController : Controller
    {
       
        private IUserService _regSerivce;

        public RegistrationController(IUserService regSerivce)
        {
            _regSerivce = regSerivce;
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
            _regSerivce.createUser(toAdd);
            return RedirectToAction("Index", "Home");
        }
    }
}