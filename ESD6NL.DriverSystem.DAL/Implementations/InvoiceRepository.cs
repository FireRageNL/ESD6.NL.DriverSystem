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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public InvoiceRepository(DriverSystemContext context) : base(context)
        {

        }

        /// <summary>
        /// Gets specific invoice by the id of that invoice from the database.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public Invoice GetSpecificInvoice(long invoiceId)
        {
            return (from x in _context.Invoices where x.invoiceNr == invoiceId select x).SingleOrDefault();
        }
    }
}
