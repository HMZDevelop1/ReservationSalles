using System;
using Microsoft.Maui.Controls;

namespace ReservationSalles.Pages
{
    public partial class DetailSallePage : ContentPage
    {
        public DetailSallePage()
        {
            InitializeComponent();
        }

        private async void OnReserverClicked(object sender, EventArgs e)
        {
            // TODO: implémenter la logique de réservation
            await DisplayAlert("Réservation", "Fonctionnalité de réservation à implémenter.", "OK");
        }

        private async void OnRetourClicked(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 0)
            {
                await Navigation.PopAsync();
            }
        }
    }
}
