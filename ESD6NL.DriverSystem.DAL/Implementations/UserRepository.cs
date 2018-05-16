using System.Linq;
using ESD6NL.DriverSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESD6NL.DriverSystem.DAL
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(DriverSystemContext context) : base(context)
        {
          
        }

        public User saveUserInDB(User usr)
        {
            return Add(usr);
        }

        public User getUserFromDatabase(string username)
        {
            User usr = (from x in _context.Users where x.userName == username select x).SingleOrDefault();
            return usr;
        }
    }
}