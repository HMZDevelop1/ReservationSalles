using Microsoft.Maui.Controls;
using ReservationSalles.Pages;

namespace ReservationSalles;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Enregistrer la route pour la page de détail
        Routing.RegisterRoute(nameof(DetailSallePage), typeof(DetailSallePage));
    }
}
