using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;

namespace FixedSize
{
    public class DTURequestInfo : RequestInfo<DTUData>
    {
        public DTURequestInfo(DTUData dtuData)
        {
            Initialize("DTUData", dtuData);//如果需要使用命令的话，那么命令类名称要和DTUData相同
        }
    }
}
