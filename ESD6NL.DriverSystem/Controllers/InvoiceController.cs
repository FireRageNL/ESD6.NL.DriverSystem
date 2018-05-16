using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESD6NL.DriverSystem.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        /// <summary>
        /// Function for getting the overview information of invoices. 
        /// </summary>
        /// <returns>invoice overview view</returns>
        public IActionResult InvoiceOverview()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Details()
        {
            return View();
        }
    }
}