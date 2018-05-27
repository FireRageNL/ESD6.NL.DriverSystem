using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ESD6NL.DriverSystem.BLL.RestModels
{
    class RestUserModel
    {
        public string FullName { get; set; }

        public string Birthday { get; set; }

        public long CitizenServiceNumber { get; set; }

        public Address Address { get; set; }

        [JsonProperty("Ownerships")]
        public List<Car> Car { get; set; }
    }

    class Address
    {
        public string Street { get; set; }

        public int StreetNr { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }

    class Car
    {
        public string CarTrackerID { get; set; }

        public string LicensePlate { get; set; }

        public Owner Owner { get; set; }
    }

    class Owner
    {
        public string FullName { get; set; }

        public string Birthday { get; set; }
    }
}
