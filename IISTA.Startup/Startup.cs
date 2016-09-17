using System;

using IISTA.Common;
using IISTA.Common.Contracts;
using IISTA.Server;
using IISTA.Loger;

namespace IISTA.Startup
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The server is strated");

            IServer server = new ServerCustom(Constants.Address, Constants.Port, new FileLogger());
            server.RunWithBrowser();
        }
    }
}
