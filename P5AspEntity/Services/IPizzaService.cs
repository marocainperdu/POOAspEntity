using P5AspEntity.Models;

namespace P5AspEntity.Services;

/// <summary>Contrat des opérations CRUD sur les pizzas.</summary>
public interface IPizzaService
{
    Task<IReadOnlyList<Pizza>> GetAllAsync(CancellationToken ct = default);
    Task<Pizza?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Pizza> CreateAsync(Pizza pizza, CancellationToken ct = default);

    /// <returns><c>false</c> si la pizza n'existe pas.</returns>
    Task<bool> UpdateAsync(int id, Pizza pizza, CancellationToken ct = default);

    /// <returns><c>false</c> si la pizza n'existe pas.</returns>
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
