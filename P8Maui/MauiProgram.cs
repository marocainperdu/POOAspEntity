using P8Maui.Extensions;

namespace P8Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        builder.Services
            .AddAppServices()
            .AddViewModels()
            .AddViews();

        return builder.Build();
    }
}
