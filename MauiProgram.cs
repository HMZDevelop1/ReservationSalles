using Microsoft.Extensions.Logging;
using ReservationSalles.Data;
using ReservationSalles.ViewModels;

namespace ReservationSalles
{
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

            // 📌 ENREGISTREMENT DES SERVICES

            // Service de données (Singleton - une seule instance pour toute l'application)
            builder.Services.AddSingleton<CarnetSalles>();

            // ViewModels (Transient - nouvelle instance à chaque utilisation)
            // ou Singleton - si vous préférez réutiliser la même instance
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<ListeSallesViewModel>();
            builder.Services.AddTransient<DetailSalleViewModel>();
            builder.Services.AddTransient<ReservationViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
