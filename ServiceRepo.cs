using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SL_TechProject.Models;
using System.Net.Http;
using System.Configuration;

namespace SL_TechProject
{
    public class ServiceRepo
    {

        public HttpClient Client { get; set; }
        public ServiceRepo()
        {
            Client = new HttpClient();
            string baseUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }

        public HttpResponseMessage PostAction(object model, string url)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
    }
}
