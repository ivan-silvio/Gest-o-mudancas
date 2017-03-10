using Dlp.Buy4.Framework.Utils;
using Owin;
using System;

namespace MsDeployLabConsole
{
    public class Startup
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="app">Owin application builder.</param>
        public void Configuration(IAppBuilder app)
        {
            // Map requests for the given route.
            app.Map("/api/whoami", (appBuilder) => {

                // Run when receive an request in this endpoint.
                appBuilder.Run((owinContext) =>
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
        }
    }
}