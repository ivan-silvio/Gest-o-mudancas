using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WhoAmIWebApplication.Controllers
{
    public class WhoAmIController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            string response = $"{Environment.MachineName} - v4";
            return response;
        }
    }
}
