using TonProjet.Models;
namespace TonProjet.Pages;
public partial class SallesPage : ContentPage{
    private List<Salle> salles;

    public SallesPage()
    {
        InitializeComponent();

        salles = new List<Salle>        {
            new Salle            {
                Nom = "Salle 201",
                Capacite = 30,
                Localisation = "Pavillon A",
                Disponible = true,
                Image = "salle.png",
                Equipements = "Projecteur, ordinateurs, tableau blanc"            },

            new Salle            {
                Nom = "Salle 204",
                Capacite = 25,
                Localisation = "Pavillon A",
                Disponible = true,
                Image = "salle.png",
                Equipements = "Projecteur, tableau blanc"            },

            new Salle            {
                Nom = "Laboratoire informatique",
                Capacite = 20,
                Localisation = "Pavillon B",
                Disponible = true,
                Image = "salle.png",
                Equipements = "Ordinateurs, projecteur, tableau blanc"            }
        };

        SallesCollectionView.ItemsSource = salles;
    }

    private async void OnSalleSelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        var salle = e.CurrentSelection.FirstOrDefault() as Salle;

        if (salle == null)
            return;

        await Shell.Current.GoToAsync(
            nameof(DetailSallePage),
            new Dictionary<string, object>            {
                { "Salle", salle }
            });

        SallesCollectionView.SelectedItem = null;
    }
}
