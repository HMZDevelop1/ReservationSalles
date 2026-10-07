using System;
using Microsoft.Maui.Controls;
using System.Linq;
using ReservationSalles.Models;

namespace ReservationSalles.Pages
{
    public partial class ReservationPage : ContentPage, IQueryAttributable
    {
        private Salle _salle;

        public ReservationPage()
        {
            InitializeComponent();
            // Remplir le picker des salles
            SallePicker.ItemsSource = ReservationData.Salles;
            DatePicker.MinimumDate = DateTime.Today;
        }

        public void ApplyQueryAttributes(System.Collections.Generic.IDictionary<string, object> query)
        {
            if (query != null && query.ContainsKey("salle") && query["salle"] is Salle s)
            {
                _salle = s;
                // sélectionner automatiquement la salle dans le picker
                SallePicker.SelectedItem = ReservationData.Salles.FirstOrDefault(x => x.Nom == s.Nom);
            }
        }

        private async void OnConfirmerClicked(object? sender, EventArgs e)
        {
            MessageValidation.IsVisible = false;

            if (string.IsNullOrWhiteSpace(NomEntrant.Text))
            {
                MessageValidation.Text = "Veuillez entrer votre nom.";
                MessageValidation.IsVisible = true;
                return;
            }

            if (SallePicker.SelectedItem == null)
            {
                MessageValidation.Text = "Veuillez sélectionner une salle.";
                MessageValidation.IsVisible = true;
                return;
            }

            if (HorairePicker.SelectedIndex < 0)
            {
                MessageValidation.Text = "Veuillez sélectionner une plage horaire.";
                MessageValidation.IsVisible = true;
                return;
            }

            var selected = SallePicker.SelectedItem as Salle;
            if (selected == null)
            {
                MessageValidation.Text = "Salle invalide.";
                MessageValidation.IsVisible = true;
                return;
            }

            if (!selected.Disponible)
            {
                await DisplayAlert("Info", "La salle n'est pas disponible.", "OK");
                return;
            }

            // Simuler la réservation
            selected.Disponible = false;
            ReservationData.ReservationCount++;
            await DisplayAlert("Confirmation", "Réservation enregistrée (simulée).", "OK");
            await Shell.Current.GoToAsync("dashboard");
        }

        private async void OnAnnulerClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("dashboard");
        }
    }
}
