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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public InvoiceService(IInvoiceRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets all the information of one specific invoice with the id of that invoice.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Invoice GetInvoice(int id)
        {
            return _repo.GetSpecificInvoice(id);
        }
    }
}
