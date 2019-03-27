using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;

namespace FixedHeader
{
    class Program
    {
        static void Main(string[] args)
        {
            MsgPackServer msgPackServer = new MsgPackServer();          

            //Setup the appServer
            if (!msgPackServer.Setup(2012)) 
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            //Try to start the appServer
            if (!msgPackServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //Stop the appServer
            msgPackServer.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
    }
}
