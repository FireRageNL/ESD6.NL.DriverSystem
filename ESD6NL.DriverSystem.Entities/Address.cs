using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNr { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}
