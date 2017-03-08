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
            string userIdentity = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string hostName = Environment.MachineName;
            string version = "1.0.1";
            return $"{userIdentity}@{hostName} Version={version}";
        }
    }
}
