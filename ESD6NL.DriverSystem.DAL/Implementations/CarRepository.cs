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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CarRepository(DriverSystemContext context) : base(context)
        {

        }

        /// <summary>
        /// Gets specific car by the id of that car from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetSpecificCar(int id)
        {
            return (from x in _context.Cars where x.CarID == id select x).SingleOrDefault();
        }
    }
}
