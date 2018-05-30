using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL.Interfaces
{
    public interface ITranslationRepository : IGenericRepository<Translation>
    {
        Translation GetTranslationFromTerm(string term, string language);
    }
}