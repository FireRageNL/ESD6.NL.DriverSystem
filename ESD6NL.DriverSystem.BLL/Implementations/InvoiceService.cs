using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepository _repo;

        public Invoice GetInvoice()
        {
            return null;
        }
    }
}
