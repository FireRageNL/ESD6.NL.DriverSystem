using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Car> GetAllCars(int citizenServiceNumber)
        {
            return _context.Cars.Include(x => x.rdwData)
                .Include(x => x.rdwFuelData)
                .Select(x => new Car
                {
                    CarID = x.CarID,
                    carTrackerID = x.carTrackerID,
                    licensePlate = x.licensePlate,
                    rdwData = x.rdwData,
                    rdwFuelData = x.rdwFuelData
                });
        }

        /// <summary>
        /// Gets specific car by the id of that car from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetSpecificCar(int id)
        {
            return _context.Cars.Where(x => x.CarID == id)
                .Include(x => x.rdwData)
                .Include(x => x.rdwFuelData)
                .Select(x => new Car
                {
                    CarID = x.CarID,
                    carTrackerID = x.carTrackerID,
                    licensePlate = x.licensePlate,
                    rdwData = x.rdwData,
                    rdwFuelData = x.rdwFuelData
                }).SingleOrDefault();
        }
    }
}
