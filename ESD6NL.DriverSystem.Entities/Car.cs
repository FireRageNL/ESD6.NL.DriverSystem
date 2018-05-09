using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    class Car
    {
        private long carTrackerId { get; set; }
        private string licencePlate { get; set; }
        private RDW rdwData { get; set; }
        private RDWFuel rdwFuelData { get; set; }
    }
}
