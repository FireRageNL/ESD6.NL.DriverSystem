using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.BLL.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars(int citizenServiceNumber);

        Car GetCar(int id);

        IEnumerable<Car> GetCarsOfUserFromAAS(long userId);
    }
}
