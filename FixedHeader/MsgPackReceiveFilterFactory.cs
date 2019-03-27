using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace FixedHeader
{
    public class MsgPackReceiveFilterFactory : IReceiveFilterFactory<BinaryRequestInfo>
    {
        public IReceiveFilter<BinaryRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new MsgPackReceiveFilter();
        }
    }
}
