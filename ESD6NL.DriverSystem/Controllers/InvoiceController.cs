using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

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
            return View();
        }

        /// <summary>
        /// Function for getting the detailed view of one invoice
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            if (invoice == null) return NotFound();

            return View(invoice);
        }
    }
}