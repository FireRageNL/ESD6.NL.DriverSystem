using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string zipCode { get; set; }

    }
}
