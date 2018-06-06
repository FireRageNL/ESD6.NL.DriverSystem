using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Invoice
    {
        public long invoiceNr { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public DateTime period { get; set; }
        public Decimal totalKm { get; set; }
        public Decimal totalAmount { get; set; }
        public string filePath { get; set; }

        public List<Row> rows { get; set; }
    }
}
