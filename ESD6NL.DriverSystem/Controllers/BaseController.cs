using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ESD6NL.DriverSystem.Controllers
{
    public class BaseController : Controller
    {
        private static ITranslationService ts;

        public BaseController(ITranslationService ts)
        {
            TranslationHelper.setService(ts);
        }
    }
}