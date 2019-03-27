using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace WhyMySelf
{
    public class MySession : AppSession<MySession,StringRequestInfo>
    {
        public string ClientType { get; set; }
    }
}
