using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User getUserFromDatabase(string username);

        User getUserFromDatabase(long csn);
    }
}
