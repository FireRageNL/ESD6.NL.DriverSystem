﻿using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return _context.Invoices.Where(x => x.invoiceNr == invoiceId).Include(y => y.rows).SingleOrDefault();
        }

        public Invoice GetLastInvoice()
        {
            return (from x in _context.Invoices orderby x.period select x).First();
        }
    }
}
