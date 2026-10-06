using System;
using Microsoft.Maui.Controls;
using ReservationSalles.Models;

namespace ReservationSalles.Pages
{
    public partial class DetailSallePage : ContentPage, IQueryAttributable
    {
        private Salle _salle;

        public DetailSallePage()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(System.Collections.Generic.IDictionary<string, object> query)
        {
            if (query != null && query.ContainsKey("salle") && query["salle"] is Salle s)
            {
                _salle = s;
                NomSalleLabel.Text = _salle.Nom;
                CapaciteLabel.Text = $"Capacité : {_salle.Capacite}";
                LocalisationLabel.Text = $"Localisation : {_salle.Localisation}";
                EquipementsLabel.Text = $"Équipements : {_salle.Equipements}";
                if (!string.IsNullOrEmpty(_salle.Image))
                    SalleImage.Source = _salle.Image;
            }
        }

        private async void OnReserverClicked(object? sender, EventArgs e)
        {
            if (_salle != null && _salle.Disponible)
            {
                var parameters = new System.Collections.Generic.Dictionary<string, object> {{ "salle", _salle }};
                await Shell.Current.GoToAsync("reservation", parameters);
            }
            else
            {
                await DisplayAlert("Info", "La salle n'est pas disponible.", "OK");
            }
        }

        private async void OnRetourClicked(object? sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 0)
            {
                await Navigation.PopAsync();
            }
        }
    }
}
