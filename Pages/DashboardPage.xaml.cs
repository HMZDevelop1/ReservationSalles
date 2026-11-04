using ReservationSalles.Models;
using ReservationSalles.Data;
using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    // Appelé chaque fois que la page s'affiche : les chiffres sont toujours à jour
    protected override void OnAppearing()
    {
        base.OnAppearing();

        int nbDisponibles = Salle.ListeSalles.Count(s => s.EstDisponible);
        labelNbSalles.Text = nbDisponibles.ToString();
        labelNbReservations.Text = new CarnetSalles().Reservations.Count.ToString();
    }

    private async void OnListeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ListeSallesPage");
    }

    private async void OnReserverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ReservationPage");
    }
}
