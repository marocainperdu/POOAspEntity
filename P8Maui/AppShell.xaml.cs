using P8Maui.Navigation;
using P8Maui.Views;

namespace P8Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Pages accessibles par navigation (hors onglets)
        Routing.RegisterRoute(Routes.Note, typeof(NotePage));
    }
}
