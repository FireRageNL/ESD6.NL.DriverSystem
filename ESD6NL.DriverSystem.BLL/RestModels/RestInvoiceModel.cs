using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.BLL.RestModels
{
    class RestInvoiceModel
    {
        public long invoiceNr { get; set; }

        public PaymentStatus paymentStatus { get; set; }

        public DateTime date { get; set; }

        public decimal totalAmount { get; set; }
    }
}
