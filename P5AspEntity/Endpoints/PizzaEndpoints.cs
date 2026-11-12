using Microsoft.AspNetCore.Http.HttpResults;
using P5AspEntity.Filters;
using P5AspEntity.Models;
using P5AspEntity.Services;

namespace P5AspEntity.Endpoints;

/// <summary>Déclare les routes de l'API des pizzas (API minimale).</summary>
public static class PizzaEndpoints
{
    public static IEndpointRouteBuilder MapPizzaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/pizzas").WithTags("Pizzas");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", GetById);
        group.MapPost("/", Create).AddEndpointFilter<ValidationFilter<Pizza>>();
        group.MapPut("/{id:int}", Update).AddEndpointFilter<ValidationFilter<Pizza>>();
        group.MapDelete("/{id:int}", Delete);

        return app;
    }

    private static async Task<Ok<IReadOnlyList<Pizza>>> GetAll(IPizzaService service, CancellationToken ct) =>
        TypedResults.Ok(await service.GetAllAsync(ct));

    private static async Task<Results<Ok<Pizza>, NotFound>> GetById(
        int id, IPizzaService service, CancellationToken ct)
    {
        var pizza = await service.GetByIdAsync(id, ct);
        return pizza is null ? TypedResults.NotFound() : TypedResults.Ok(pizza);
    }

    private static async Task<Created<Pizza>> Create(Pizza pizza, IPizzaService service, CancellationToken ct)
    {
        var created = await service.CreateAsync(pizza, ct);
        return TypedResults.Created($"/pizzas/{created.Id}", created);
    }

    private static async Task<Results<NoContent, NotFound>> Update(
        int id, Pizza pizza, IPizzaService service, CancellationToken ct) =>
        await service.UpdateAsync(id, pizza, ct) ? TypedResults.NoContent() : TypedResults.NotFound();

    private static async Task<Results<NoContent, NotFound>> Delete(
        int id, IPizzaService service, CancellationToken ct) =>
        await service.DeleteAsync(id, ct) ? TypedResults.NoContent() : TypedResults.NotFound();
}
