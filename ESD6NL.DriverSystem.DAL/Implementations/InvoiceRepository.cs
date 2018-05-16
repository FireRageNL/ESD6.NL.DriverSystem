using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.DAL.Implementations
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DriverSystemContext context) : base(context)
        {

        }

        public Invoice GetSpecificInvoice(int invoiceId)
        {
            return null;
        }
    }
}
