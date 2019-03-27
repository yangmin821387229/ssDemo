namespace InGenericTypes
{
    public interface IServer
    {
        void Connect();
    }

    public interface IServer<TSession> : IServer where TSession : ISession, new()
    {
        event SessionConnect<TSession> NewSessionConnected;
    }

    public delegate void SessionConnect<TSession>(TSession session);
}