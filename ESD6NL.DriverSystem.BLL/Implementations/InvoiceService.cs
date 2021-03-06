﻿using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using ESD6NL.DriverSystem.BLL.Helpers;
using ESD6NL.DriverSystem.BLL.RestModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepository _repo;

        private IRowRepository _rowRepo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public InvoiceService(IInvoiceRepository repo, IRowRepository rowRepo)
        {
            _repo = repo;
            _rowRepo = rowRepo;
        }

        public List<Invoice> GetAllInvoices(long citizenServiceNumber)
        {
            HttpResponseMessage response = RestHelper.AasHttpClient().GetAsync($"invoices/" + citizenServiceNumber).Result;
            response.EnsureSuccessStatusCode();
            var foundInvoices = response.Content.ReadAsStringAsync().Result;
            var invoiceModels = JsonConvert.DeserializeObject<List<RestInvoiceModel>>(foundInvoices);
            List<Invoice> foundInvoicesJson = new List<Invoice>();
            invoiceModels.ForEach(i => foundInvoicesJson.Add(new Invoice()
            {
                invoiceNr = i.invoiceNr,
                paymentStatus = (PaymentStatus) Enum.Parse(typeof(PaymentStatus),i.paymentStatus),
                period = i.date,
                totalAmount = i.totalAmount

            }));
            foundInvoicesJson.ForEach(i =>
            {
                if (_repo.GetSpecificInvoice(i.invoiceNr) == null)
                {
                    _repo.Add(i);
                }
            });
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

            RestInvoiceModel restInvoiceModel = new RestInvoiceModel();
            restInvoiceModel.invoiceNr = invoice.invoiceNr;
            restInvoiceModel.paymentStatus = "PAID";

            var JsonObject = JsonConvert.SerializeObject(restInvoiceModel);
            var httpContent = new StringContent(JsonObject);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = RestHelper.AasHttpClient().PutAsync($"invoices", httpContent).Result;
            response.EnsureSuccessStatusCode();
        }

        public Invoice getLastInvoice()
        {
            return _repo.GetLastInvoice();
        }
    }
}
