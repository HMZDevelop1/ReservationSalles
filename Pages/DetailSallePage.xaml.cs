using TonProjet.Models;
namespace TonProjet.Pages;

[QueryProperty(nameof(Salle), "Salle")]public partial class DetailSallePage : ContentPage{
    private Salle salle;

    public Salle Salle    {
        get => salle;
        set        {
            salle = value;

            if (salle != null)
            {
                AfficherSalle();
            }
        }
    }

    public DetailSallePage()
    {
        InitializeComponent();
    }

    private void AfficherSalle()
    {
        NomSalleLabel.Text = salle.Nom;
        CapaciteLabel.Text = $"Capacité : {salle.Capacite} personnes";
        LocalisationLabel.Text = $"Localisation : {salle.Localisation}";
        EquipementsLabel.Text = salle.Equipements;
        SalleImage.Source = salle.Image;
    }

    private async void OnReserverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(ReservationPage),
            new Dictionary<string, object>            {
                { "Salle", salle }
            });
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
