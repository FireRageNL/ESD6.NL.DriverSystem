using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Translation
    {
        public int TranslationID { get; set; }

        public string Term { get; set; }

        public string Language { get; set; }

        public string Translated { get; set; }
    }
}
