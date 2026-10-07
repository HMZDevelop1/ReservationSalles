using System;
using System.Linq;
using Microsoft.Maui.Controls;
using ReservationSalles.Models;

namespace ReservationSalles.Pages;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Mettre à jour les compteurs depuis les données simulées
        var available = ReservationData.Salles.Count(s => s.Disponible);
        var reservations = ReservationData.ReservationCount;
        AvailableCountLabel.Text = available.ToString();
        ReservationCountLabel.Text = reservations.ToString();
    }

    private async void OnVoirSallesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//salles");
    }

    private async void OnReservationClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//reservation");
    }
}
