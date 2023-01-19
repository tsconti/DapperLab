namespace DapperLab.CustomQuery;

public sealed class DbSession : IDisposable, IDbSession
{
    public System.Data.IDbConnection Connection { get; }

    public DbSession(IDbConnectionFactory dbConnectionFactory)
    {
        Connection = dbConnectionFactory.GetConnection();
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
