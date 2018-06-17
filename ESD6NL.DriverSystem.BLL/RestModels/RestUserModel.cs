using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.Entities;
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
