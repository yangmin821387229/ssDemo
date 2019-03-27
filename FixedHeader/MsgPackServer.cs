using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace FixedHeader
{
    public class MsgPackServer : AppServer<MsgPackSession, BinaryRequestInfo>
    {
        public MsgPackServer() : base(new MsgPackReceiveFilterFactory())
        {
            
        }
    }
}
