using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class SehirController : ApiController
    {
        private string[] sehirler = new string[] { "antalya", "eskişehir", "istanbul" };
        public string[] Get()
        {
            return sehirler;
        }
        public string Get(int id)
        {
            return sehirler[id];
        }
    }
}
