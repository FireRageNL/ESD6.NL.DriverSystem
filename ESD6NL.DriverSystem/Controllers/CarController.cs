using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carService"></param>
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Overview action result. Shows all the cars of an owner.
        /// </summary>
        /// <returns></returns>
        public IActionResult CarOverview()
        {
            return View();
        }

        /// <summary>
        /// Detail action result. Shows all the details of one specific car.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var car = _carService.GetCar(id);
            if (car == null) return NotFound();

            return View(car);
        }
    }
}