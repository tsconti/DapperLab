using DapperLab.CustomQuery.Enums;

namespace DapperLab.CustomQuery;

public interface IDbConnectionConfig
{
    public string Database { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Host { get; set; }
    public string Port { get; set; }
    public DbProvider Type { get; set; }
    public string GetConnectionString();
}
