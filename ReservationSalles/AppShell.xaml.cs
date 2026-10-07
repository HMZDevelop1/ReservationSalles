using Microsoft.Maui.Controls;

namespace ReservationSalles
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Enregistrer la route pour la page de détail
            Routing.RegisterRoute("DetailSallePage", typeof(Pages.DetailSallePage));
        }
    }
}
