using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.Models
{
    public class RowModel
    {

        public DateTime date;
        public string dayOfWeek;
        public decimal km;
        public decimal costs;
        public int rowId;

        public RowModel(DateTime date, string dayOfWeek, decimal km, decimal costs)
        {
            this.date = date;
            this.dayOfWeek = dayOfWeek;
            this.km = km;
            this.costs = costs;
        }

        public RowModel()
        {
        }

    }
}

