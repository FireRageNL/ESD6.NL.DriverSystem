using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.DAL.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        IEnumerable<Car> GetAllCars(int citizenServiceNumber);
        Car GetSpecificCar(int id);
    }
}
