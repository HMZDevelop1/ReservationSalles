using ReservationSalles.Pages;

namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Page de détail : pas dans le menu, mais on enregistre sa route
        // pour pouvoir y naviguer avec GoToAsync
        Routing.RegisterRoute(nameof(DetailSallePage), typeof(DetailSallePage));
    }
}
