﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carService"></param>
        public CarController(ICarService carService, ITranslationService ts, IUserService us): base(ts,us)
        {
            _carService = carService;
        }

        /// <summary>
        /// Overview action result. Shows all the cars of an owner.
        /// </summary>
        /// <returns></returns>
        public IActionResult CarOverview()
        {
            IEnumerable<Car> cars = _carService.GetCarsOfUserFromAAS(getUser().citizenServiceNumber);
            var userViewModel = FillUserViewModel(cars);

            return View(userViewModel);
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
            var carViewModel = FillCarViewModel(car);

            return View(carViewModel);
        }

        public UserViewModel FillUserViewModel(IEnumerable<Car> car)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.cars.AddRange(car);
            return userViewModel;
        }

        public CarViewModel FillCarViewModel(Car car)
        {
            CarViewModel carViewModel = new CarViewModel();
            carViewModel.car = car;
            return carViewModel;
        }
    }
}