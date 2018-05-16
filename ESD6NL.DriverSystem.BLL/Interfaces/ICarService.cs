using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.BLL.Interfaces
{
    public interface ICarService
    {
        Car GetCar(int id);
    }
}
