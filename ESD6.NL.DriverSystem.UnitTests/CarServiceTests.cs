using ESD6NL.DriverSystem.BLL.Implementations;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESD6.NL.DriverSystem.UnitTests
{
    [TestClass]
    public class CarServiceTests
    {
        private CarService _carService;

        public CarServiceTests()
        {
            var mock = new Mock<ICarRepository>();
            mock.Setup(garage => garage.GetSpecificCar(1)).Returns(new Car()
            {
                CarID = 1,
                carTrackerID = "1",
                rdwData = new RDW(),
                rdwFuelData = new RDWFuel()
            });
            mock.Setup(garage => garage.GetSpecificCar(2)).Returns(new Car
            {
                CarID = 2,
                carTrackerID = "2",
                rdwData = new RDW(),
                rdwFuelData = new RDWFuel()
            });
            mock.Setup(garage => garage.Add(It.IsAny<Car>())).Returns((Car c) => c);
            List<Car> cars = new List<Car>
            {
                new Car()
                {
                    CarID = 1,
                    carTrackerID = "1",
                    rdwData = new RDW(),
                    rdwFuelData = new RDWFuel(),
                    licensePlate = "asdf123"
                },
                new Car()
                {
                    CarID = 2,
                    carTrackerID = "2",
                    rdwData = new RDW(),
                    rdwFuelData = new RDWFuel(),
                    licensePlate = "123asdf"
                }
            };
            mock.Setup(garage => garage.getCarsForUser(123456L)).Returns(cars);
            _carService = new CarService(mock.Object);
        }

        [TestMethod]
        public void getSpecificCar_ExcistingCar_CarDetails()
        {
            Assert.AreEqual("1", _carService.GetCar(1).carTrackerID);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), 
            "An id is used that does not yet excist.")]
        public void getSpecificCar_FakeCar_ErrorMessage()
        {
            var testvalue = _carService.GetCar(2).carTrackerID;
        }

        [TestMethod]
        public void getCaforspecificUser_validCSN_ReturnsTwo()
        {
            Assert.AreEqual(2, _carService.GetCarsOfUserFromAAS(123456L).ToList().Count);
        }

        [TestMethod]
        public void updateCarsForUser_validCars()
        {
            _carService.updateCarsForUser(new User()
            {
                citizenServiceNumber = 123456L,
                cars = new List<Car>()
            });
        }
    }
}
