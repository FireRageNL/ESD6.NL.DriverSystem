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
            return foundCarsJson;
        }
    }
}
