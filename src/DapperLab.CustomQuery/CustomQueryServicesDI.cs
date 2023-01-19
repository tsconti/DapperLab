using Microsoft.Extensions.DependencyInjection;

namespace DapperLab.CustomQuery;

public static class CustomQueryServicesDI
{
    public static IServiceCollection AddPersonalFrameworkDatabaseCustomQueryServices(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped<IDbSession, DbSession>();

        return services;
    }
}
