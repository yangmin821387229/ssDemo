using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;

namespace FixedSize
{
    public class DTUFixedSizeReceiveFilter : FixedSizeReceiveFilter<DTURequestInfo>
    {
        public DTUFixedSizeReceiveFilter() : base(25)//总的字节长度 1+1+2+5+1+5+2+6+1+1 = 25
        {
        }

        protected override DTURequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length, bool toBeCopied)
        {
            var dtuData = new DTUData();

            dtuData.Head = (char)buffer[offset];//上行包头的解析，1个字节
            dtuData.Ping = buffer[offset + 1];//心跳包数据，从第2位起，只有1个字节
            dtuData.Lenght = BitConverter.ToUInt16(buffer, offset + 2);//数据长度，从第3位开始，2个字节
            dtuData.FID = BitConverter.ToUInt32(buffer, offset + 4);//本终端ID，从第5位开始，5个字节
            dtuData.Type = buffer[offset + 9];//目标类型，从第10位开始，1个字节
            dtuData.SID = BitConverter.ToUInt32(buffer, offset + 10);//转发终端ID，从第11位开始，5个字节
            dtuData.SendCount = BitConverter.ToUInt16(buffer, offset + 15);//发送包计数，从第16位开始，2个字节
            dtuData.Retain = buffer.CloneRange(offset + 17, 6);//保留字段，从18位开始，6个字节
            dtuData.Check = buffer[offset + 23];//异或校验，从24位开始，1个字节
            dtuData.End = (char)buffer[offset+24];//结束符号，从第25位开始，一个字节

            return new DTURequestInfo(dtuData);
        }
    }
}
