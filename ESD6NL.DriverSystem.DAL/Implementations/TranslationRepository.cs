using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL.Implementations
{
    public class TranslationRepository : GenericRepository<Translation>, ITranslationRepository
    {
        public TranslationRepository(DriverSystemContext context) : base(context)
        {
        }

        public Translation GetTranslationFromTerm(string term, string language)
        {
            return (from x in _context.Translations where x.Term == term && x.Language == language select x).SingleOrDefault();
        }
    }
}
