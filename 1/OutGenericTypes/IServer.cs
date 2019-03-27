using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutGenericTypes
{
    public interface IServer
    {
        event SessionConnect NewSessionConnected;
        void Connect();
    }

    public delegate void SessionConnect(ISession session);
}