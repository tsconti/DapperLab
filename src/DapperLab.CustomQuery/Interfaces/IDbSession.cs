namespace DapperLab.CustomQuery;

public interface IDbSession
{
    System.Data.IDbConnection Connection { get; }

    void Dispose();
}
