using P8Maui.Models;

namespace P8Maui.Services;

/// <summary>Stockage des notes (remplaçable : fichiers, SQLite, API...).</summary>
public interface INoteRepository
{
    Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct = default);
    Task<Note?> GetAsync(string id, CancellationToken ct = default);
    Task SaveAsync(Note note, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
}
