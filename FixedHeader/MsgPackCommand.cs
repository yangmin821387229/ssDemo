using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MsgPack.Serialization;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace FixedHeader
{
    public abstract class MsgPackCommand<TMsgPack> : CommandBase<MsgPackSession, BinaryRequestInfo> where TMsgPack : class
    {
        public override void ExecuteCommand(MsgPackSession session, BinaryRequestInfo requestInfo)
        {
            var serializer = SerializationContext.Default.GetSerializer<TMsgPack>();
            using (var stream = new MemoryStream(requestInfo.Body))
            {
                var unpackedObject = serializer.Unpack(stream) as TMsgPack;
                ExecuteCommand(session, unpackedObject);
            }
            
        }

        public abstract void ExecuteCommand(MsgPackSession session, TMsgPack pack);
    }
}
