using ESD6NL.DriverSystem.BLL.Helpers;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class CarService : ICarService
    {
        private ICarRepository _repo;
        private Car foundCar;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public CarService(ICarRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Car> GetAllCars(int citizenServiceNumber)
        {
            return _repo.GetAllCars(citizenServiceNumber);
        }

        /// <summary>
        /// Gets all the information of one specific car with the id of that car. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            return _repo.GetSpecificCar(id);
        }

        public IEnumerable<Car> GetCarsOfUserFromAAS(int userId)
        {
            HttpResponseMessage response = RestHelper.AasHttpClient().GetAsync($"cars").Result;
            response.EnsureSuccessStatusCode();
            var foundCars = response.Content.ReadAsStringAsync().Result;
            var foundCarsJson = JsonConvert.DeserializeObject<List<Car>>(foundCars); 

            IEnumerable<Car> cars = foundCarsJson as IEnumerable<Car>;
            foreach(Car c in cars)
            {
                c.rdwData = findRdwByLicensePlate(c.licensePlate);
                c.rdwFuelData = findRdwFuelByLicensePlate(c.licensePlate);
            }
            return cars;
        }

        public RDW findRdwByLicensePlate(string licensePlate)
        {
            string url = "?kenteken=" + licensePlate.Replace("-", "");
            HttpResponseMessage response = RestHelper.RdwHttpClient().GetAsync(url).Result;
            var rdwDataJson = JsonConvert.DeserializeObject<RDW>(RestHelper.ConvertRdwData(response));
            return rdwDataJson;
        }

        public RDWFuel findRdwFuelByLicensePlate(string licensePlate)
        {
            string url = "?kenteken=" + licensePlate.Replace("-", "");
            HttpResponseMessage response = RestHelper.RdwFuelHttpClient().GetAsync(url).Result;
            var rdwDataJson = JsonConvert.DeserializeObject<RDWFuel>(RestHelper.ConvertRdwData(response));
            return rdwDataJson;
        }
    }
}
