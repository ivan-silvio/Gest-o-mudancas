using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsDeployLabConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string mySetting = ConfigurationManager.AppSettings["MySetting"];
            Console.WriteLine(mySetting);

            Console.ReadKey();
        }
    }
}
