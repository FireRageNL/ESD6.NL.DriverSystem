using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Helpers;
using ESD6NL.DriverSystem.BLL.RestModels;
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Newtonsoft.Json;

namespace ESD6NL.DriverSystem.BLL
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;
        

        public UserService(IUserRepository repo)
        {
            _repo = repo;
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
            string a = "a";

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
    }
}