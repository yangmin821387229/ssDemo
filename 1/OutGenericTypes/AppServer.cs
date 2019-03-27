using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutGenericTypes
{
    public class AppServer : IServer
    {
        public event SessionConnect NewSessionConnected;

        public virtual void Connect()
        {
            Connect(new AppSession());
        }

        protected void Connect(ISession session)
        {
            session.Server = this;
            session.Id = Guid.NewGuid().ToString();
            if (NewSessionConnected != null)
            {
                NewSessionConnected(session);
            }
        }

    }
}