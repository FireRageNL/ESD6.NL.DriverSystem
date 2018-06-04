using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IUserService _userService;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoiceController(IInvoiceService invoiceService, ITranslationService ts, IUserService userService) : base(ts)
        {
            _invoiceService = invoiceService;
            _userService = userService;
        }

        /// <summary>
        /// Function for getting the overview information of invoices. 
        /// </summary>
        /// <returns>invoice overview view</returns>
        public IActionResult InvoiceOverview()
        {
            string username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            Entities.User usr = _userService.getserByUsername(username);

            var invoice = _invoiceService.GetAllInvoices(usr.citizenServiceNumber) as List<Invoice>;
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
            invoiceViewModel.totalEuros = invoice.totalAmount.ToString("0#.##", CultureInfo.InvariantCulture);
            invoiceViewModel.rows = invoice.rows;
            return invoiceViewModel;
        }
    }
}