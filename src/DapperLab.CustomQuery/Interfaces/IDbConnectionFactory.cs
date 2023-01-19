namespace DapperLab.CustomQuery;

public interface IDbConnectionFactory
{
    System.Data.IDbConnection GetConnection();
}
