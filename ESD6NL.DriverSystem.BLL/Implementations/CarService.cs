using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class CarService : ICarService
    {
        private ICarRepository _repo;

        public CarService(ICarRepository repo)
        {
            _repo = repo;
        }

        public Car GetCar(int id)
        {
            return _repo.GetSpecificCar(id);
        }
    }
}
