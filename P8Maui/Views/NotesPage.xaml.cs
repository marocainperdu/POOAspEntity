using P8Maui.ViewModels;

namespace P8Maui.Views;

public partial class NotesPage : ContentPage
{
    private readonly NotesViewModel _viewModel;

    public NotesPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    // Recharge la liste à chaque retour sur la page (après ajout, modification ou suppression)
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadCommand.Execute(null);
    }
}
