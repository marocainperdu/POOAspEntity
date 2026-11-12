using CommunityToolkit.Mvvm.Input;

namespace P8Maui.ViewModels;

public partial class AboutViewModel
{
    public string AppName => AppInfo.Name;
    public string Version => $"Version {AppInfo.VersionString}";
    public string Description => "Application de prise de notes écrite en XAML et C# avec .NET MAUI.";

    [RelayCommand]
    private Task LearnMoreAsync() => Launcher.Default.OpenAsync("https://learn.microsoft.com/dotnet/maui");
}
