using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int carTrackerID { get; set; }
        public string licencePlate { get; set; }
        public RDW rdwData { get; set; }
        public RDWFuel rdwFuelData { get; set; }
    }
}
