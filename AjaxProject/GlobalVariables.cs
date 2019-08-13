using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AjaxProject
{
    public class GlobalVariables
    {
        public static HttpClient userapi = new HttpClient();
        static GlobalVariables()
        {
            userapi.BaseAddress = new Uri("http://localhost:55703/api/");
            userapi.DefaultRequestHeaders.Clear();
            userapi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}