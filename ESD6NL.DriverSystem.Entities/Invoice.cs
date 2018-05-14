using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    public class Invoice
    {
        public int invoiceID { get; set; }
        public long invoiceNumber { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public DateTime period { get; set; }
        public int totalKm { get; set; }
        public Decimal totalAmount { get; set; }
        public string filePath { get; set; }
    }
}
