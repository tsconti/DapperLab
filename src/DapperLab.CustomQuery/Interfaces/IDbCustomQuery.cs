namespace DapperLab.CustomQuery;

public interface IDbCustomQuery
{
    public string Query { get; set; }

    void SetQuery(string query);

    Task<IEnumerable<dynamic>> ExecuteAsync(object parameters);
}
