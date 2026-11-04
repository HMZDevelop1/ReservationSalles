using ReservationSalles.Models;
using ReservationSalles.Data;
using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class ListeSallesPage : ContentPage
{
    public ListeSallesPage()
    {
        InitializeComponent();

        // On donne la liste de salles à la CollectionView
        listeSalles.ItemsSource = Salle.ListeSalles;
    }

    private async void OnDetailsClicked(object sender, EventArgs e)
    {
        // Le bouton sait à quelle salle il appartient grâce au BindingContext
        Button bouton = (Button)sender;
        Salle salle = (Salle)bouton.BindingContext;

        // On passe l'identifiant de la salle à la page de détail (paramètre simple)
        await Shell.Current.GoToAsync($"{nameof(DetailSallePage)}?salleId={salle.Id}");
    }
}
