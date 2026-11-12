namespace P8Maui.Services;

public interface INavigationService
{
    /// <summary>Ouvre la page de note ; <paramref name="noteId"/> null = nouvelle note.</summary>
    Task GoToNoteAsync(string? noteId = null);

    Task GoBackAsync();
}
