using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public string licensePlate { get; set; }
        public string carTrackerID { get; set; }
        public RDW rdwData { get; set; }
        public RDWFuel rdwFuelData { get; set; }
    }
}
