using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Helpers;
using ESD6NL.DriverSystem.BLL.Implementations;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.BLL.RestModels;
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Newtonsoft.Json;
using Car = ESD6NL.DriverSystem.Entities.Car;

namespace ESD6NL.DriverSystem.BLL
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;

        private ICarService _carService;
        

        public UserService(IUserRepository repo, ICarService carServce)
        {
            _repo = repo;
            _carService = carServce;
        }

        public User createUser(User toSave)
        {
            toSave.password = generatePassword(toSave.password);
            RegistrationModel model = new RegistrationModel{LastName = toSave.lastName, CitizenServiceNumber = toSave.citizenServiceNumber, FirstName = toSave.firstName};
            HttpResponseMessage response = RestHelper.AasHttpClient()
                .PostAsync($"owners", RestHelper.ConvertToSendableHttpObject(model)).Result;
            response.EnsureSuccessStatusCode();
            string msg = response.Content.ReadAsStringAsync().Result;
            RestUserModel mod = JsonConvert.DeserializeObject<RestUserModel>(msg);
            toSave.address = mod.Address;
            toSave.birthDay = DateTime.ParseExact(mod.Birthday,"dd-MM-yyyy",System.Globalization.CultureInfo.InvariantCulture);
            toSave.cars = _carService.GetCarsOfUserFromAAS(toSave.citizenServiceNumber) as List<Car>;
            toSave.Language = "NLD";
            return _repo.Add(toSave);
        }

        private string generatePassword(string password)
        {
            string salt = HashingHelper.getSalt();
            return salt + ":"+ HashingHelper.generatePasswordHash(password, salt);
        }

        public bool checkUserLogin(string password, string username)
        {
            User LoginTry = _repo.getUserFromDatabase(username);
            if (LoginTry == null)
            {
                return false;
            }
            string[] passwordHashStrings = LoginTry.password.Split(':');
            return HashingHelper.Validate(password, passwordHashStrings[0], passwordHashStrings[1]);
        }

        public User getserByUsername(string username)
        {
            return _repo.getUserFromDatabase(username);
        }

        public void saveUser(User usr)
        {
            _repo.Update(usr);
        }
    }
}