namespace ReservationSalles.Pages;

// Le paramètre "salleId" de la navigation va dans la propriété SalleId
[QueryProperty(nameof(SalleId), "salleId")]
public partial class DetailSallePage : ContentPage
{
    private int idSalle;

    public DetailSallePage()
    {
        InitializeComponent();
    }

    // Cette propriété est remplie automatiquement à la navigation
    public string SalleId
    {
        set
        {
            idSalle = int.Parse(value);
            AfficherSalle();
        }
    }

    private void AfficherSalle()
    {
        Salle? salle = Salle.ListeSalles.FirstOrDefault(s => s.Id == idSalle);
        if (salle == null)
        {
            return;
        }

        labelNom.Text = salle.Nom;
        labelDisponibilite.Text = salle.TexteDisponibilite;
        labelDisponibilite.TextColor = salle.CouleurDisponibilite;
        labelDescription.Text = salle.Description;
        labelCapacite.Text = salle.TexteCapacite;
        labelLocalisation.Text = salle.Localisation;
        labelEquipements.Text = salle.Equipements;

        // On ne peut pas réserver une salle occupée
        boutonReserver.IsEnabled = salle.EstDisponible;
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");   // ".." = retour à la page précédente
    }

    private async void OnReserverClicked(object sender, EventArgs e)
    {
        // On passe la salle choisie au formulaire de réservation
        await Shell.Current.GoToAsync($"//ReservationPage?salleId={idSalle}");
    }
}
