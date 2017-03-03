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
    [RoutePrefix("api/settings")]
    public class SettingsController : ApiController
    {
        public class ConfigurationHueHue
        {
            public string Name { get; set; }
        }


        [HttpGet]
        [Route("appsettings/{key}")]
        public string GetAppSettings(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            return value;
        }

        [HttpGet]
        [Route("provider")]
        public string GetProviderSettings()
        {
            try
            {
                ConfigurationHueHue config = Dlp.Buy4.Infrastructure.ConfigurationProvider.Load<ConfigurationHueHue>("HueHue");
                string value = config?.Name;
                return value;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpGet]
        [Route("connstring/{name}")]
        public string GetConnString(string name)
        {
            string value = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            return value;
        }
    }
}
