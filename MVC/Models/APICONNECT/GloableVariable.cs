using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC.Models.APICONNECT
{
    public static class GloableVariable
    {
        public static HttpClient WepApiAddress = new HttpClient();

        static GloableVariable()
        {
            WepApiAddress.BaseAddress = new Uri("http://localhost:51279/api/");
            WepApiAddress.DefaultRequestHeaders.Clear();
            WepApiAddress.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}