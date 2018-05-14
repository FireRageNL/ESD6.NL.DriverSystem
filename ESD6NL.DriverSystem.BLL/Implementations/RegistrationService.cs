using System;
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;

namespace ESD6NL.DriverSystem.BLL
{
    public class RegistrationService : IRegistrationService
    {
        private IGenericRepository<User> _repo;

        public RegistrationService(IGenericRepository<User> repo)
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
    }
}