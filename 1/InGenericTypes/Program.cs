using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InGenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            AppServerUse();
            Console.WriteLine("-----------这是分割线----------------");
            TelnetServerUse();
            Console.ReadKey();
        }

        static void AppServerUse()
        {
            var server = new AppServer();
            server.NewSessionConnected += AppServer_NewSessionConnected;
            server.Connect();
        }

        static void TelnetServerUse()
        {
            var server = new TelnetServer();
            server.NewSessionConnected += TelnetServer_NewSessionConnected;
            server.Connect();
        }

        private static void AppServer_NewSessionConnected(AppSession session)
        {
            Console.WriteLine("使用的session类型:{0},\nsession的id:{1},\n使用的server类型:{2}",
                session, session.Id, session.Server);
        }

        private static void TelnetServer_NewSessionConnected(TelnetSession session)
        {
            Console.WriteLine("使用的session类型:{0},\nsession的id:{1},\n使用的server类型:{2}",
                session, session.Id, session.Server);
        }
    }
}
