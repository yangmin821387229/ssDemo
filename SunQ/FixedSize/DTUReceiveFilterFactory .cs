using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace FixedSize
{
    public class DTUReceiveFilterFactory : IReceiveFilterFactory<DTURequestInfo>
    {
        public IReceiveFilter<DTURequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new DTUBeginEndMarkReceiveFilter();
            //return new DTUFixedSizeReceiveFilter();
        }
    }
}
