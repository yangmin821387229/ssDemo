using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace FixedHeader
{
    public class Test : MsgPackCommand<MyData>
    {
        public override void ExecuteCommand(MsgPackSession session, MyData pack)
        {
            Console.WriteLine(pack.Name+":"+ pack.Other);
        }
    }
}
