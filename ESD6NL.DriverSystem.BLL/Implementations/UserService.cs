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
        private HttpClient _client = new HttpClient();
        

        public UserService(IUserRepository repo)
        {
            _repo = repo;
            _client.BaseAddress = new Uri("http://localhost:8080/AccountAdministrationSystem/api/");
        }

        public async Task<User> createUser(User toSave)
        {
            string salt = HashingHelper.getSalt();
            string pwHash = HashingHelper.generatePasswordHash(toSave.password, salt);
            string pwSave = salt + ":" + pwHash;
            toSave.password = pwSave;
            RegistrationModel model = new RegistrationModel{LastName = toSave.lastName, CitizenServiceNumber = toSave.citizenServiceNumber, FirstName = toSave.firstName};   
            HttpResponseMessage response = await _client.PutAsync($"owner", RestHelper.convertToSendableHttpObject(model));
            response.EnsureSuccessStatusCode();
           return _repo.Add(toSave);
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