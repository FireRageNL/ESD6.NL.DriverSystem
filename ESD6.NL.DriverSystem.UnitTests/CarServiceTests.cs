using ESD6NL.DriverSystem.BLL.Implementations;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
                carTrackerID = 1,
                rdwData = new RDW(),
                rdwFuelData = new RDWFuel()
            });
            mock.Setup(garage => garage.Add(It.IsAny<Car>())).Returns((Car c) => c);
            _carService = new CarService(mock.Object);
        }

        [TestMethod]
        public void getSpecificCar_ExcistingCar_CarDetails()
        {
            Assert.AreEqual(1, _carService.GetCar(1).carTrackerID);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), 
            "An id is used that does not yet excist.")]
        public void getSpecificCar_FakeCar_ErrorMessage()
        {
            var testvalue = _carService.GetCar(2).carTrackerID;
        }
    }
}
