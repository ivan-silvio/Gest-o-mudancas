using Dlp.Buy4.Framework.Utils;
using Owin;
using System;
using Dlp.Buy4.Infrastructure.Service.Owin;
using Dlp.Buy4.Framework.Service.Owin;
using System.Configuration;

namespace WhoAmIWinService
{
    public class Startup
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="appBuilder">Owin application builder.</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            string url = ConfigurationManager.AppSettings["ListenUrl"];
            appBuilder.AddListenUrl(url);

            // Map requests for the given route.
            appBuilder.Map("/api/whoami", (appBuilder2) => {

                // Run when receive an request in this endpoint.
                appBuilder2.Run((owinContext) =>
                {
                    try
                    {
                        string userIdentity = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        string hostName = Environment.MachineName;
                        string version = ProductInfo.Global.Version;
                        string whoami = $"{userIdentity}@{hostName} Version={version}";

                        // return 200 Ok.
                        owinContext.Response.ContentType = "text/plain";
                        return owinContext.Response.WriteAsync(whoami);
                    }
                    // Unexpected exception, must return http status code 500.
                    catch (Exception e)
                    {
                        owinContext.Response.StatusCode = 500;
                        return owinContext.Response.WriteAsync(e.ToString());
                    }
                });
            });

            appBuilder.Map("/api/settings/appsettings", (appBuilder2) => {

                // Run when receive an request in this endpoint.
                appBuilder2.Run((owinContext) =>
                {
                    try
                    {
                        string setting = ConfigurationManager.AppSettings["MySetting"];

                        // return 200 Ok.
                        owinContext.Response.ContentType = "text/plain";
                        return owinContext.Response.WriteAsync(setting);
                    }
                    // Unexpected exception, must return http status code 500.
                    catch (Exception e)
                    {
                        owinContext.Response.StatusCode = 500;
                        return owinContext.Response.WriteAsync(e.ToString());
                    }
                });
            });
        }
    }
}