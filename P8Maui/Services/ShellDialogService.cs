namespace P8Maui.Services;

public sealed class ShellDialogService : IDialogService
{
    // DisplayAlert est marquée obsolète au profit de DisplayAlertAsync dans les versions récentes
    // de .NET MAUI ; elle reste fonctionnelle.
#pragma warning disable CS0618
    public Task AlertAsync(string title, string message, string cancel = "OK") =>
        Shell.Current.DisplayAlert(title, message, cancel);

    public Task<bool> ConfirmAsync(string title, string message, string accept = "Oui", string cancel = "Non") =>
        Shell.Current.DisplayAlert(title, message, accept, cancel);
#pragma warning restore CS0618
}
