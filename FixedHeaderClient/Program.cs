using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using MsgPack.Serialization;

namespace FixedHeaderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1",2012);
            using (var stream = new MemoryStream())
            {
                var serializer = SerializationContext.Default.GetSerializer<MyData>();
                var myData = new MyData()
                {
                    Name = "Test",
                    Other = "abcd"
                };

                serializer.Pack(stream, myData);

                //var commandData = new byte[4];//协议命令只占4位
                var commandData = Encoding.UTF8.GetBytes("Test");//协议命令只占4位,如果占的位数长过协议，那么协议解析肯定会出错的

                var dataBody = stream.ToArray();

                var dataLen = BitConverter.GetBytes(dataBody.Length);//int类型占4位，根据协议这里也只能4位，否则会出错

                var sendData = new byte[8+dataBody.Length];//命令加内容长度为8

                // +-------+---+-------------------------------+
                // |request| l |                               |
                // | name  | e |    request body               |
                // |  (4)  | n |                               |
                // |       |(4)|                               |
                // +-------+---+-------------------------------+

                Array.ConstrainedCopy(commandData, 0, sendData, 0, 4);
                Array.ConstrainedCopy(dataLen, 0, sendData, 4,4);
                Array.ConstrainedCopy(dataBody, 0, sendData, 8, dataBody.Length);


                byte[] buffer = new byte[] { 0xFF };
                for (int i = 0; i < 10; i++)
                {
                    socket.Send(sendData);
                }
                socket.Send(buffer);
                socket.Send(buffer);
                for (int i = 0; i < 1000000; i++)
                {
                    socket.Send(sendData);
                }
            }

            Console.Read();
        }
    }
}
