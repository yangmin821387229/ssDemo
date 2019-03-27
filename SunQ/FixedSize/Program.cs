using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedSize
{
    class Program
    {
        static void Main(string[] args)
        {
            DTUServer dtuServer = new DTUServer();

            //Setup the appServer
            if (!dtuServer.Setup(2012))
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            dtuServer.NewRequestReceived += DtuServer_NewRequestReceived;

            Console.WriteLine();

            //Try to start the appServer
            if (!dtuServer.Start())
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
            dtuServer.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        /// <summary>
        /// 协议并没有什么太多复杂逻辑，不需要用到命令模式，直接用这种方式就可以了
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        private static void DtuServer_NewRequestReceived(DTUSession session, DTURequestInfo requestInfo)
        {
            Console.WriteLine();
            Console.WriteLine(requestInfo.Body);
        }
    }
}
