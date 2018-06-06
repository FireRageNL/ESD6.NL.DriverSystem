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
        private static readonly string Identity = "oSCOrcWPw3tbNxp802mR";
        private static string jwtToken;

        public static StringContent ConvertToSendableHttpObject(object T)
        {
            var jsonModel = JsonConvert.SerializeObject(T);
            var httpContent = new StringContent(jsonModel);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public static HttpClient AasHttpClient()
        {
            if (aasClient == null)
            {
                aasClient = new HttpClient()
                {
                    BaseAddress = new Uri("http://192.168.25.122:8080/AccountAdministrationSystem/api/")
                };
            }

            if (jwtToken == null)
            {
                //HttpResponseMessage response =
                //    aasClient.PostAsync($"identify", ConvertToSendableHttpObject(Identity)).Result;
                //response.EnsureSuccessStatusCode();
                //string msg = response.Content.ReadAsStringAsync().Result;
                jwtToken = "lol";
            }

            aasClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",jwtToken);
            return aasClient;
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


