using DapperLab.CustomQuery;
using DapperLab.CustomQuery.Enums;

namespace MyComponentCustomQuery;

public class DbConnectionConfig : IDbConnectionConfig
{
    public string Database { get; set; }
    public string Username { get; set; }    
    public string Password { get; set; }    
    public string Host { get; set; }
    public string Port { get; set; }
    public DbProvider DbProvider { get; set; } = DbProvider.MsSql;

    public string GetConnectionString()
    {
        return $"Server={Host};Database={Database};User={Username};Password={Password}";
    }
}
