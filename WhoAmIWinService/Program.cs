using Dlp.Buy4.Framework.Service;
using System;
using System.ComponentModel;
using System.Configuration;

namespace MsDeployLabConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new Dlp.Buy4.Infrastructure.Service.IntegratedWebServiceApplication<Startup>();
                service.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

    /// <summary>
    /// Installer for the program.
    /// </summary>
    [RunInstaller(true)]
    public class ProgramInstaller : ServiceApplicationInstaller { }

}
