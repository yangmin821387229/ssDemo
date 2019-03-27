using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;

namespace FixedHeader
{
    /// +-------+---+-------------------------------+
    /// |request| l |                               |
    /// | name  | e |    request body               |
    /// |  (4)  | n |                               |
    /// |       |(4)|                               |
    /// +-------+---+-------------------------------+
    public class MsgPackReceiveFilter : FixedHeaderReceiveFilter<BinaryRequestInfo>
    {
        public MsgPackReceiveFilter() : base(8)
        {
        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            var headerData = new byte[4];
            Array.Copy(header,offset+4,headerData,0,4);
            return BitConverter.ToInt32(headerData, 0);
        }

        protected override BinaryRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            return new BinaryRequestInfo(Encoding.UTF8.GetString(header.Array, header.Offset, 4), bodyBuffer.CloneRange(offset, length));
        }
    }
}
