using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        public IActionResult CarOverview()
        {
            return View();
        }
    }
}