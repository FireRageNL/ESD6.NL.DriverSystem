using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ESD6NL.DriverSystem.Helpers
{
    public static class InvoiceHelpercs
    {
        public static InvoiceViewModel FillInvoiceViewModel(Invoice invoice)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel
            {
                invoiceId = invoice.invoiceNr,
                date = invoice.period,
                totalKm = invoice.totalKm,
                totalEuros = invoice.totalAmount.ToString("0#.##", CultureInfo.InvariantCulture),
                rows = invoice.rows
            };
            return invoiceViewModel;
        }
    }
}
