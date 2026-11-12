using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P8Maui.Models;
using P8Maui.Navigation;
using P8Maui.Services;

namespace P8Maui.ViewModels;

/// <summary>Création / modification / suppression d'une note.</summary>
public partial class NoteViewModel(
    INoteRepository repository,
    INavigationService navigation,
    IDialogService dialogs) : ObservableObject, IQueryAttributable
{
    private Note _note = new();

    [ObservableProperty]
    private string _text = string.Empty;

    [ObservableProperty]
    private bool _isExisting;

    /// <summary>Reçoit le paramètre "id" de la navigation Shell (absent = nouvelle note).</summary>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(Routes.NoteIdQuery, out var value) && value is string id && id.Length > 0)
            _ = LoadAsync(id);
    }

    private async Task LoadAsync(string id)
    {
        var existing = await repository.GetAsync(id);
        if (existing is null)
        {
            await dialogs.AlertAsync("Note introuvable", "Cette note n'existe plus.");
            await navigation.GoBackAsync();
            return;
        }

        _note = existing;
        Text = existing.Text;
        IsExisting = true;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Text))
        {
            await dialogs.AlertAsync("Note vide", "Saisissez du texte avant d'enregistrer.");
            return;
        }

        _note.Text = Text;
        await repository.SaveAsync(_note);
        await navigation.GoBackAsync();
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (!await dialogs.ConfirmAsync("Supprimer", "Voulez-vous vraiment supprimer cette note ?"))
            return;

        await repository.DeleteAsync(_note.Id);
        await navigation.GoBackAsync();
    }
}
