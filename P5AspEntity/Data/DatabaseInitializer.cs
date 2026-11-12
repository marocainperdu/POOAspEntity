using Microsoft.EntityFrameworkCore;
using P5AspEntity.Models;

namespace P5AspEntity.Data;

/// <summary>Crée la base SQLite au démarrage et l'alimente si elle est vide.</summary>
public static class DatabaseInitializer
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PizzaDb>();

        await db.Database.EnsureCreatedAsync();

        if (await db.Pizzas.AnyAsync())
            return;

        db.Pizzas.AddRange(
            new Pizza { Name = "Margherita", Description = "Tomate, mozzarella et basilic" },
            new Pizza { Name = "Reine", Description = "Tomate, mozzarella, jambon et champignons" },
            new Pizza { Name = "Quatre fromages", Description = "Mozzarella, gorgonzola, parmesan et chèvre" },
            new Pizza { Name = "Végétarienne", Description = "Poivrons, oignons, olives et champignons" });

        await db.SaveChangesAsync();
    }
}
