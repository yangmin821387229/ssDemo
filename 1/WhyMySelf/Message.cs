using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace WhyMySelf
{
    public class Message : CommandBase<MySession, StringRequestInfo>
    {
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("客户端的类型是:{0},收到的消息是{1}",
                session.ClientType,requestInfo.Body);
        }
    }
}
