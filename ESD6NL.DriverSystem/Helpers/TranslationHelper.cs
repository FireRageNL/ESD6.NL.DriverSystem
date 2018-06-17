using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ESD6NL.DriverSystem.BLL.Enums;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESD6NL.DriverSystem.Helpers
{
    public static class TranslationHelper
    {
        private static ITranslationService _service;

        public static void setService(ITranslationService service)
        {
            _service = service;
        }

        public static IHtmlContent getTerm(this IHtmlHelper htmlHelper, string term)
        {
            string lang = htmlHelper.ViewContext.HttpContext.Request.Cookies["Language"];
            if (lang == null || !Enum.IsDefined(typeof(Language),lang))
            {
                lang = "NLD";
            }
            string translated = _service.Translate(term, lang);
            return new HtmlString(translated);
        }

    }
}
