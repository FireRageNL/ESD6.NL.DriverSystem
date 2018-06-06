using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.BLL.Enums;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class TranslationService : ITranslationService
    {
        private ITranslationRepository _repo;

        public TranslationService(ITranslationRepository repo)
        {
            _repo = repo;
        }

        public string Translate(string term, string language)
        {
            Translation trans =  _repo.GetTranslationFromTerm(term, language);
            return trans != null ? trans.Translated : addTranslation(term);
        }

        public string addTranslation(string text)
        {
            foreach (Language l in Enum.GetValues(typeof(Language)))
            {
                Translation tr = new Translation{Language = l.ToString(), Term = text, Translated = text};
                _repo.Add(tr);
            }
            return text;
        }
    }
}
