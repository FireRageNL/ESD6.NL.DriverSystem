using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.Models
{
    public class InvoiceViewModel
    {
        public long invoiceId { get; set; }
        public DateTime date { get; set; }
        public Decimal totalKm { get; set; }
        public string totalEuros { get; set; }
        public List<RowModel> rows { get; set; }

        public bool paid { get; set; }
    }
}
