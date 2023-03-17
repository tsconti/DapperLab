using Microsoft.Extensions.DependencyInjection;
using MyComponentCustomQuery;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using DapperLab.CustomQuery;
using CustomQueryConsoleApp.CustomQuery;

Console.WriteLine("Custom Query ConsoleApp!");

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services => {
    // Load configuration in your way, this is only for this sample app
    services.AddSingleton<IDbConnectionConfig>(serviceProvider =>
    {
        var appConfiguration = new DbConnectionConfig
        {
            Host = "blablabla.us-west-2.redshift.amazonaws.com",
            Port = "5439",
            Database = "stock",
            Username = "myuser",
            Password = "mypass"
    };
        return appConfiguration;
    });
    services.AddDapperCustomQueryServices();
    services.AddScoped<SimpleQuery>();
    services.AddScoped<StockQuery>();
    services.AddScoped<StartMyQuery>();
    services.AddScoped<StartMySimpleQuery>();
});

var host = builder.Build();

//var myStart = host.Services.GetRequiredService<StartMySimpleQuery>();
var myStart = host.Services.GetRequiredService<StartMyQuery>();

await myStart.RunAsync();

public class StartMyQuery
{
    private readonly StockQuery _query;

    public StartMyQuery(StockQuery query)
    {
        _query = query;
    }

    public async Task RunAsync()
    {
        var stock = await _query.ExecuteAsync(1);

        Console.WriteLine(JsonSerializer.Serialize(stock));
    }
}

public class StartMySimpleQuery
{
    private readonly SimpleQuery _query;

    public StartMySimpleQuery(SimpleQuery query)
    {
        _query = query;
    }

    public async Task RunAsync()
    {
        var simple = await _query.ExecuteAsync(true);

        Console.WriteLine(JsonSerializer.Serialize(simple));
    }
}
