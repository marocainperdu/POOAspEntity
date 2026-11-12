using P8Maui.Models;

namespace P8Maui.Services;

/// <summary>Une note = un fichier texte dans le dossier de données de l'application.</summary>
public sealed class FileNoteRepository : INoteRepository
{
    private const string Extension = ".note.txt";
    private readonly string _directory;

    public FileNoteRepository(string directory)
    {
        _directory = directory;
        Directory.CreateDirectory(_directory);
    }

    public async Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken ct = default)
    {
        var notes = new List<Note>();
        foreach (var path in Directory.EnumerateFiles(_directory, "*" + Extension))
            notes.Add(await ReadAsync(path, ct));

        return notes.OrderByDescending(n => n.Date).ToList();
    }

    public async Task<Note?> GetAsync(string id, CancellationToken ct = default)
    {
        var path = PathFor(id);
        return File.Exists(path) ? await ReadAsync(path, ct) : null;
    }

    public async Task SaveAsync(Note note, CancellationToken ct = default)
    {
        var path = PathFor(note.Id);
        await File.WriteAllTextAsync(path, note.Text, ct);
        note.Date = File.GetLastWriteTime(path);
    }

    public Task DeleteAsync(string id, CancellationToken ct = default)
    {
        var path = PathFor(id);
        if (File.Exists(path))
            File.Delete(path);

        return Task.CompletedTask;
    }

    // Path.GetFileName empêche toute sortie du dossier (ex. "../")
    private string PathFor(string id) => Path.Combine(_directory, Path.GetFileName(id) + Extension);

    private static async Task<Note> ReadAsync(string path, CancellationToken ct) => new()
    {
        Id = Path.GetFileName(path)[..^Extension.Length],
        Text = await File.ReadAllTextAsync(path, ct),
        Date = File.GetLastWriteTime(path)
    };
}
