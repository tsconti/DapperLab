using Dapper;

namespace DapperLab.CustomQuery;

public abstract class DbCustomQuery : IDbCustomQuery
{
    public string Query { get; set; }

    private readonly IDbSession _session;

    protected DbCustomQuery(IDbSession session)
    {
        _session = session;
    }

    public void SetQuery(string query)
    {
        Query = query;
    }

    public async Task<IEnumerable<dynamic>> ExecuteAsync(object parameters)
    {
        var result = await _session.Connection.QueryAsync(Query, parameters);

        return result;
    }

}
