
namespace P5AspEntity.Extensions;

public static class WebApplicationExtensions
{
    /// <summary>Configure le pipeline HTTP (OpenAPI en développement, HTTPS, page d'accueil).</summary>
    public static WebApplication UsePizzaStore(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.MapOpenApi(); // description OpenAPI : /openapi/v1.json

        app.UseHttpsRedirection();
        app.MapGet("/", () => Results.Redirect("/pizzas")).ExcludeFromDescription();

        return app;
    }
}
