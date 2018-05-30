using System.Globalization;

namespace ESD6NL.DriverSystem.BLL.Interfaces
{
    public interface ITranslationService
    {
        string Translate(string term, string language);

        string addTranslation(string text);
    }
}