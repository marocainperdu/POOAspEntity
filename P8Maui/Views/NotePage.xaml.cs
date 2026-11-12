using P8Maui.ViewModels;

namespace P8Maui.Views;

public partial class NotePage : ContentPage
{
    public NotePage(NoteViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
