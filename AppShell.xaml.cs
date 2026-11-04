using ReservationSalles.Pages;

namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Pages hors menu : on enregistre leurs routes.
        // Les noms doivent être identiques à ceux utilisés dans les ViewModels
        // ("DetailSallePage" et "ReservationPage").
        Routing.RegisterRoute(nameof(DetailSallePage), typeof(DetailSallePage));
        Routing.RegisterRoute(nameof(ReservationPage), typeof(ReservationPage));
    }
}
