using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    public class CarController : Controller
    {
        public IActionResult CarOverview()
        {
            return View();
        }
    }
}