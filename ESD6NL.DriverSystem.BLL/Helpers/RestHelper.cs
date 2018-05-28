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
        private static HttpClient aasClient;
        private static HttpClient rdwClient;
        private static HttpClient rdwFuelClient;

        public static StringContent ConvertToSendableHttpObject(object T)
        {
            var jsonModel = JsonConvert.SerializeObject(T);
            var httpContent = new StringContent(jsonModel);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public static HttpClient AasHttpClient()
        {
            return aasClient ?? (aasClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/AccountAdministrationSystem/api/")
            });
        }

        public static HttpClient RdwHttpClient()
        {
            return rdwClient ?? (rdwClient = new HttpClient
            {
                BaseAddress = new Uri("http://opendata.rdw.nl/resource/m9d7-ebf2.json")
            });
        }

        public static HttpClient RdwFuelHttpClient()
        {
            return rdwFuelClient ?? (rdwFuelClient = new HttpClient
            {
                BaseAddress = new Uri("http://opendata.rdw.nl/resource/8ys7-d773.json")
            });
        }

        public static string ConvertRdwData(HttpResponseMessage rdwData)
        {
            var result = rdwData.Content.ReadAsStringAsync().Result;
            var resreplace = result.Replace("[", "");
            return resreplace.Replace("]", "");
        }
    }
}


