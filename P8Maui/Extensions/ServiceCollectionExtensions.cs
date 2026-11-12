using P8Maui.Services;
using P8Maui.ViewModels;
using P8Maui.Views;

namespace P8Maui.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<INoteRepository>(_ => new FileNoteRepository(FileSystem.AppDataDirectory));
        services.AddSingleton<INavigationService, ShellNavigationService>();
        services.AddSingleton<IDialogService, ShellDialogService>();
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<NotesViewModel>();
        services.AddTransient<NoteViewModel>();
        services.AddTransient<AboutViewModel>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddTransient<NotesPage>();
        services.AddTransient<NotePage>();
        services.AddTransient<AboutPage>();
        return services;
    }
}
