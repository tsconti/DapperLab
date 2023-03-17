using DapperLab.CustomQuery.Enums;
using Npgsql;
using System.Data.SqlClient;

namespace DapperLab.CustomQuery;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IDbConnectionConfig _config;

    public DbConnectionFactory(IDbConnectionConfig config)
    {
        _config = config;
    }
    
    public System.Data.IDbConnection GetConnection()
    {
        switch (_config.DbProvider)
        {
            case DbProvider.MsSql:
                return new SqlConnection(_config.GetConnectionString());

            case DbProvider.Postgres:
            case DbProvider.Redshift:
                return new NpgsqlConnection(_config.GetConnectionString());

            default:
                throw new NotImplementedException(_config.DbProvider.ToString());
        }
    }
}
