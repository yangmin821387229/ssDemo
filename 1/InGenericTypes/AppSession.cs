namespace InGenericTypes
{
    public class AppSession<TSession> : ISession<TSession> where TSession : ISession, new()
    {
        public string Id { get; set; }
        public IServer<TSession> Server { get; set; }
    }

    public class AppSession : AppSession<AppSession>
    {
    }

}