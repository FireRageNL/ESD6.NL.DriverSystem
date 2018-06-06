using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IEnumerable<Car> getCarsForUser(long citizenServiceNumber)
        {
            User usr = _context.Users.SingleOrDefault(x => x.citizenServiceNumber == citizenServiceNumber) ?? throw new ArgumentNullException("_context.Users.Where(x => x.citizenServiceNumber == citizenServiceNumber).SingleOrDefault()");
            return usr.cars;
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
