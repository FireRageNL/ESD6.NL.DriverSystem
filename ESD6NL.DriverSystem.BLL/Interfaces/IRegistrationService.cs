using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.BLL
{
    public interface IRegistrationService
    {
        User createUser(User toSave);
    }
}