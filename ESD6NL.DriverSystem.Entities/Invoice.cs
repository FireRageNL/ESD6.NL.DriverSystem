using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.Entities
{
    class Invoice
    {
        private long invoiceNumber { get; set; }
        private PaymentStatus paymentStatus { get; set; }
        private DateTime period { get; set; }
        private Decimal totalAmount { get; set; }
        private string filePath { get; set; }
    }
}
