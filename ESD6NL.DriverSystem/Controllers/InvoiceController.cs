using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Function for getting the overview information of invoices. 
        /// </summary>
        /// <returns>invoice overview view</returns>
        public IActionResult InvoiceOverview()
        {
            var invoice = _invoiceService.GetAllInvoices(88888888888) as List<Invoice>;
            var userViewModel = FillUserViewModel(invoice);

            return View(userViewModel);
        }

        /// <summary>
        /// Function for getting the detailed view of one invoice
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            if (invoice == null) return NotFound();
            var invoiceViewModel = FillInvoiceViewModel(invoice);

            return View(invoiceViewModel);
        }

        public UserViewModel FillUserViewModel(IEnumerable<Invoice> invoices)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.invoices.AddRange(invoices);
            return userViewModel;
        }

        public InvoiceViewModel FillInvoiceViewModel(Invoice invoice)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            invoiceViewModel.invoiceId = invoice.invoiceID;
            invoiceViewModel.date = invoice.period;
            invoiceViewModel.totalKm = invoice.totalKm;
            invoiceViewModel.totalEuros = invoice.totalAmount;
            invoiceViewModel.rows = invoice.rows;
            return invoiceViewModel;
        }
    }
}