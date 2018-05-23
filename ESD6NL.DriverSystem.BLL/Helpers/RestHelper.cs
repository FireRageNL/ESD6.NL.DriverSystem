using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ESD6NL.DriverSystem.BLL.Helpers
{
    public class RestHelper
    {
        public static StringContent convertToSendableHttpObject(Object T)
        {
            var jsonModel = JsonConvert.SerializeObject(T);
            var httpContent = new StringContent(jsonModel);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }
    }
}
