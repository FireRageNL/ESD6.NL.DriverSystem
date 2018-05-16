using ESD6NL.DriverSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.DAL.Interfaces
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Invoice GetSpecificInvoice(int invoiceId);
    }
}
