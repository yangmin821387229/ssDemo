using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WhyMyselfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var threada = new Thread(SendA);
            threada.Start();

            var threadb = new Thread(SendB);
            threadb.Start();

            Console.ReadKey();
        }

        private static void SendA()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 2012);
            if (socket.Connected)
            {
                socket.Send(Encoding.UTF8.GetBytes("ClientType A_Client\r\n"));
                Thread.Sleep(1000);
                for (int i = 0; i < 10; i++)
                    socket.Send(Encoding.UTF8.GetBytes("Message AAAAAAAA\r\n"));
            }
        }

        private static void SendB()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 2012);
            if (socket.Connected)
            {
                socket.Send(Encoding.UTF8.GetBytes("ClientType B_Client\r\n"));
                Thread.Sleep(1000);
                for (int i = 0; i < 10; i++)
                    socket.Send(Encoding.UTF8.GetBytes("Message BBBBBBBBB\r\n"));
            }
        }
    }
}
