using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ESD6NL.DriverSystem.DAL.Implementations
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(DriverSystemContext context) : base(context)
        {

        }

        public Car GetSpecificCar(int id)
        {
            return (from x in _context.Cars where x.CarID == id select x).SingleOrDefault();
        }
    }
}
