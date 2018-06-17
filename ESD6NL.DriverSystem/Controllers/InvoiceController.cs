using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
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
        private readonly IRowService _rowService;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="invoiceService"></param>
        public InvoiceController(IInvoiceService invoiceService, ITranslationService ts, IUserService userService, IRowService rowService) : base(ts,userService)
        {
            _invoiceService = invoiceService;
            _userService = userService;
            _rowService = rowService;
        }

        /// <summary>
        /// Function for getting the overview information of invoices. 
        /// </summary>
        /// <returns>invoice overview view</returns>
        public IActionResult InvoiceOverview()
        {

            var invoice = _invoiceService.GetAllInvoices(getUser().citizenServiceNumber) as List<Invoice>;
            var userViewModel = FillUserViewModel(invoice);

            return View(userViewModel);
        }

        public IActionResult Map(int id)
        {
            var row = _rowService.getSpecificRow(id);
            RowModel model = new RowModel
            {
                costs = row.costs,
                rowId = row.rowId,
                route = row.navigatedRoutes,
                dayOfWeek = row.dayOfWeek,
                date = row.date,
                km = row.km
            };
            return View(model);
        }

        public IActionResult PaymentProcessed()
        {
            string auth = "ncFfxRN13LECpr3gI2SXXAWJpv3CW5nC_SiovkaDuPdVhrVx_TBAs0me9Hu";
            string txToken = Request.Query["tx"].ToString();
            string query = "cmd=_notify-synch&tx=" + txToken + "&at=" + auth;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(query);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            Dictionary<string, string> results = new Dictionary<string, string>();
            if (strResponse != "")
            {
                StringReader reader = new StringReader(strResponse);
                string line = reader.ReadLine();

                if (line == "SUCCESS")
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        results.Add(line.Split('=')[0], line.Split('=')[1]);

                    }
                    string paidInvoice = results["item_name"];
                    Regex rx = new Regex(@"[^0-9]");
                    string invoicenr = rx.Replace(paidInvoice, "");
                    int paidInvoiceId = Int32.Parse(invoicenr);

                    _invoiceService.updateInvoice(paidInvoiceId);
                }
            }

            

            return RedirectToAction("InvoiceOverview");
        }
        /// <summary>
        /// Function for getting the detailed view of one invoice
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            if (invoice == null) return NotFound();
            var invoiceViewModel = InvoiceHelpercs.FillInvoiceViewModel(invoice);

            return View(invoiceViewModel);
        }

        public UserViewModel FillUserViewModel(IEnumerable<Invoice> invoices)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.invoices.AddRange(invoices);
            return userViewModel;
        }
    }
}