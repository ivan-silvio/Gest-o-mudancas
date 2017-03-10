using System;
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
}
