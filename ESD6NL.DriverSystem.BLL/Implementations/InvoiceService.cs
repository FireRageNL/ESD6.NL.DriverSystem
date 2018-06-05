using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using ESD6NL.DriverSystem.BLL.Helpers;
using Newtonsoft.Json;

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

        public List<Invoice> GetAllInvoices(long citizenServiceNumber)
        {
            HttpResponseMessage response = RestHelper.AasHttpClient().GetAsync($"invoices/" + citizenServiceNumber).Result;
            response.EnsureSuccessStatusCode();
            var foundInvoices = response.Content.ReadAsStringAsync().Result;
            var foundInvoicesJson = JsonConvert.DeserializeObject<List<Invoice>>(foundInvoices);

            foreach (Invoice i in foundInvoicesJson)
            {
                if (_repo.GetSpecificInvoice(i.invoiceNr) == null)
                {
                    _repo.Add(i);
                }
            }
            return foundInvoicesJson;
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

        public void updateInvoice(int paidInvoiceId)
        {
            Invoice invoice = _repo.GetSpecificInvoice(paidInvoiceId);
            invoice.paymentStatus = 0;
            _repo.Update(invoice);
        }
    }
}
