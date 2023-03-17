using DapperLab.CustomQuery;
using DapperLab.CustomQuery.Enums;

namespace MyComponentCustomQuery;

public class PgDbConnectionConfig : IDbConnectionConfig
{
    public string Database { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Host { get; set; }
    public string Port { get; set; }
    public DbProvider DbProvider { get; set; } = DbProvider.Postgres;

    public string GetConnectionString()
    {
        return $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
    }
}
