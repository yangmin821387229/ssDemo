using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace WhyMySelf
{
    public class ClientType : CommandBase<MySession, StringRequestInfo>
    {
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("客户端[{0}]发送了标记",requestInfo.Body);
            session.ClientType = requestInfo.Body;
        }
    }
}
