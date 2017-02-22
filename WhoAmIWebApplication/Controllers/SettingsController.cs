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
    public class SettingsController : ApiController
    {

        [HttpGet]
        public string GetSettings()
        {
            string value = ConfigurationManager.AppSettings["MySetting"];
            return value;
        }
    }
}
