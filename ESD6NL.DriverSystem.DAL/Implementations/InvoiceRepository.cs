using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ESD6NL.DriverSystem.DAL.Implementations
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DriverSystemContext context) : base(context)
        {

        }

        public Invoice GetSpecificInvoice(int invoiceId)
        {
            return (from x in _context.Invoices where x.invoiceID == invoiceId select x).SingleOrDefault();
        }
    }
}
