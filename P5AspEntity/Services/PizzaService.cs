using Microsoft.EntityFrameworkCore;
using P5AspEntity.Data;
using P5AspEntity.Models;

namespace P5AspEntity.Services;

/// <summary>Implémentation EF Core de <see cref="IPizzaService"/>.</summary>
public sealed class PizzaService(PizzaDb db) : IPizzaService
{
    public async Task<IReadOnlyList<Pizza>> GetAllAsync(CancellationToken ct = default) =>
        await db.Pizzas.AsNoTracking().OrderBy(p => p.Id).ToListAsync(ct);

    public Task<Pizza?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Pizzas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<Pizza> CreateAsync(Pizza pizza, CancellationToken ct = default)
    {
        // On ignore l'Id éventuellement envoyé par le client : la base le génère.
        var entity = new Pizza { Name = pizza.Name.Trim(), Description = pizza.Description };

        db.Pizzas.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, Pizza pizza, CancellationToken ct = default)
    {
        var entity = await db.Pizzas.FindAsync([id], ct);
        if (entity is null)
            return false;

        entity.Name = pizza.Name.Trim();
        entity.Description = pizza.Description;
        await db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await db.Pizzas.FindAsync([id], ct);
        if (entity is null)
            return false;

        db.Pizzas.Remove(entity);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
