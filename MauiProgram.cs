using Microsoft.Extensions.Logging;
using ReservationSalles.Data;
using ReservationSalles.Pages;
using ReservationSalles.ViewModels;

namespace ReservationSalles;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Le carnet est partagé par toute l'application (un seul exemplaire)
        builder.Services.AddSingleton<CarnetSalles>();

        // Les ViewModels
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<ListeSallesViewModel>();
        builder.Services.AddTransient<DetailSalleViewModel>();
        builder.Services.AddTransient<ReservationViewModel>();

        // Les pages (elles reçoivent leur ViewModel dans le constructeur)
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<ListeSallesPage>();
        builder.Services.AddTransient<DetailSallePage>();
        builder.Services.AddTransient<ReservationPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
