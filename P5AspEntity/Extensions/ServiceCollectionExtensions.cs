using P5AspEntity.Data;
using P5AspEntity.Services;

namespace P5AspEntity.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>Enregistre EF Core (SQLite), les services métier et OpenAPI.</summary>
    public static IServiceCollection AddPizzaStore(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

        services.AddSqlite<PizzaDb>(connectionString);
        services.AddScoped<IPizzaService, PizzaService>();
        services.AddOpenApi();

        return services;
    }
}
