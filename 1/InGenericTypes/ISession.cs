namespace InGenericTypes
{
    public interface ISession
    {
        string Id { get; set; }
    }

    public interface ISession<TSession>: ISession where TSession : ISession, new()
    {
        IServer<TSession> Server { get; set; }
    }
}