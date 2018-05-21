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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public CarService(ICarRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets all the information of one specific car with the id of that car. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            return _repo.GetSpecificCar(id);
        }
    }
}
