using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P8Maui.Models;
using P8Maui.Services;

namespace P8Maui.ViewModels;

/// <summary>Liste des notes.</summary>
public partial class NotesViewModel(INoteRepository repository, INavigationService navigation) : ObservableObject
{
    public ObservableCollection<Note> Notes { get; } = [];

    [ObservableProperty]
    private bool _isEmpty = true;

    [RelayCommand]
    private async Task LoadAsync()
    {
        var notes = await repository.GetAllAsync();

        Notes.Clear();
        foreach (var note in notes)
            Notes.Add(note);

        IsEmpty = Notes.Count == 0;
    }

    [RelayCommand]
    private Task AddAsync() => navigation.GoToNoteAsync();

    [RelayCommand]
    private Task OpenAsync(Note? note) =>
        note is null ? Task.CompletedTask : navigation.GoToNoteAsync(note.Id);
}
