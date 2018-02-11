using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AKQA.Web.WebService;
using System.Net;

namespace AKQA.Web.WebService
{
    public class ApiService : IApiService
    {
        private string url = ConfigurationManager.AppSettings["BaseURL"];
        private const string apiAction = "api/AKQAService/GetAmountValue?amount=";

        /// <summary>
        /// Interface implementation: Call web client to return data from service.
        /// </summary>
        /// <param name="param">holds decimal amount in string</param>
        /// <returns>Converted amount in words</returns>
        public string GetAPIData(string param)
        {
            string baseUrl = url + apiAction + param;
            string response = string.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");//
                response = client.DownloadString(baseUrl);
            }
            return response;
        }
    }
}
