using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.BLL.Interfaces
{
    public interface ICarService
    {
        Car GetCar(int id);

        IEnumerable<Car> GetCarsOfUserFromAAS(int userId);
    }
}
