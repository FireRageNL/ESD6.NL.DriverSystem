using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Row
    {
        public int rowId { get; set; }
        public DateTime date { get; set; }
        public string dayOfWeek { get; set; }
        public Decimal km { get; set; }
        public Decimal costs { get; set; }

    }
}
