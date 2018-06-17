using System;
using ESD6NL.DriverSystem.BLL.Helpers;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Gets all the information of one specific car with the id of that car. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCar(int id)
        {
            return _repo.GetSpecificCar(id);
        }

        public IEnumerable<Car> GetCarsOfUserFromAAS(long csn)
        {
            HttpResponseMessage response = RestHelper.AasHttpClient().GetAsync($"cars/" + csn).Result;
            response.EnsureSuccessStatusCode();
            var foundCars = response.Content.ReadAsStringAsync().Result;
            var userCars = JsonConvert.DeserializeObject<IEnumerable<Car>>(foundCars);
            List<Car> filledCars = new List<Car>();
            userCars.ToList().ForEach(c =>
            {
                Car cr = GetCar(c.CarID);
                filledCars.Add(cr ?? c);
            });
            return filledCars;
        }

        public void updateCarsForUser(User usr)
        {
           IEnumerable<Car> cars = GetCarsOfUserFromAAS(usr.citizenServiceNumber);
           cars.ToList().ForEach(c =>
           {
               var match = usr.cars.Where(ca => String.Equals(ca.licensePlate, c.licensePlate));
               if (!match.Any())
               {
                   usr.cars.Add(c);
               }
           });
            List<Car> toRemove = new List<Car>();
        usr.cars.ForEach(c =>
        {
            var match = cars.ToList().Where(ca => String.Equals(ca.licensePlate, c.licensePlate));
            if (!match.Any())
            {
                toRemove.Add(c);
            }
        });
        toRemove.ForEach(c => usr.cars.Remove(c));
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
