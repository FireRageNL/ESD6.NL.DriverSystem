using System.Threading.Tasks;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.BLL
{
    public interface IUserService
    {
        User createUser(User toSave);

        bool checkUserLogin(string password, string username);

        User getserByUsername(string username);
    }
}