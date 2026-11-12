using P8Maui.Navigation;

namespace P8Maui.Services;

public sealed class ShellNavigationService : INavigationService
{
    public Task GoToNoteAsync(string? noteId = null)
    {
        var route = noteId is null
            ? Routes.Note
            : $"{Routes.Note}?{Routes.NoteIdQuery}={Uri.EscapeDataString(noteId)}";

        return Shell.Current.GoToAsync(route);
    }

    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
