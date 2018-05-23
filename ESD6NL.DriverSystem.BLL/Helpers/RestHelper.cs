using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ESD6NL.DriverSystem.BLL.Helpers
{
    public static class RestHelper
    { 
        private static HttpClient assClient;

        public static StringContent ConvertToSendableHttpObject(object T)
        {
            var jsonModel = JsonConvert.SerializeObject(T);
            var httpContent = new StringContent(jsonModel);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public static HttpClient AasHttpClient()
        {
            return assClient ?? (assClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/AccountAdministrationSystem/api/")
            });
        }
    }
}
