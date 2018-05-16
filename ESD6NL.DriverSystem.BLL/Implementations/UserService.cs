using System;
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;

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
            string salt = HashingHelper.getSalt();
            string pwHash = HashingHelper.generatePasswordHash(toSave.password, salt);
            string pwSave = salt + ":" + pwHash;
            toSave.password = pwSave;
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