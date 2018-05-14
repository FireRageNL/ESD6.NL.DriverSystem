using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.Models
{
    public class InvoiceViewModel
    {
        int invoiceId { get; set; }
        DateTime date { get; set; }
        int totalKm { get; set; }
        decimal totalEuros { get; set; }
        List<Rule> rule { get; set; }
    }
}
