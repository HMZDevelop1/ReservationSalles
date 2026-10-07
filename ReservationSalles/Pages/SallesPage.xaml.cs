using System;
using Microsoft.Maui.Controls;
using ReservationSalles.Models;
using System.Collections.Generic;

namespace ReservationSalles.Pages
{
    public partial class SallesPage : ContentPage
    {
        public SallesPage()
        {
            InitializeComponent();
            SallesCollectionView.ItemsSource = ReservationData.Salles;
        }

        private async void OnSalleSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selected = e.CurrentSelection[0] as Salle;
                if (selected != null)
                {
                    // Navigation vers la page de détail en passant l'objet
                    var parameters = new Dictionary<string, object>{{"salle", selected}};
                    await Shell.Current.GoToAsync("DetailSallePage", parameters);
                }
            }
            // Réinitialiser la sélection
            if (sender is CollectionView cv)
                cv.SelectedItem = null;
        }
    }
}
