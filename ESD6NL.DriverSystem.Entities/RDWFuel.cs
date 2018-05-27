using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class RDWFuel
    {
        public int RDWFuelID { get; set; }
        public string brandstof_omschrijving { get; set; }
        public string brandstof_volgnummer { get; set; }
        public string brandstofverbruik_buiten { get; set; }
        public string brandstofverbruik_gecombineerd { get; set; }
        public string brandstofverbruik_stad { get; set; }
        public string co2_uitstoot_gecombineerd { get; set; }
        public string emissiecode_omschrijving { get; set; }
        public string geluidsniveau_stationair { get; set; }
        public string kenteken { get; set; }
        public string milieuklasse_eg_goedkeuring_licht { get; set; }
        public string nettomaximumvermogen { get; set; }
        public string toerental_geluidsniveau { get; set; }
    }
}
