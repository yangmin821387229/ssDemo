using System;

namespace InGenericTypes
{
    public class AppServer<TSession> : IServer<TSession> where TSession:ISession<TSession>,new()
    {
        public event SessionConnect<TSession> NewSessionConnected;

        public void Connect()
        {
            var session = new TSession
            {
                Server = this,
                Id = Guid.NewGuid().ToString()
            };
            if (NewSessionConnected != null)
            {
                NewSessionConnected(session);
            }
        }
    }

    public class AppServer : AppServer<AppSession>
    {
    }
}