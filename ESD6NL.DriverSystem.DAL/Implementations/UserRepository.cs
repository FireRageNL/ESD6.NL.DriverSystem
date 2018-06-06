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
            return _context.Users.Include(x => x.cars).SingleOrDefault(x => x.userName == username);
        }
    }
}