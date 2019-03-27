using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;

namespace FixedSize
{
    public class DTUServer : AppServer<DTUSession, DTURequestInfo>
    {
        public DTUServer() : base(new DTUReceiveFilterFactory())
        {
            
        }
    }
}
