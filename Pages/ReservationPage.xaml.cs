namespace ReservationSalles.Pages;

[QueryProperty(nameof(SalleId), "salleId")]
public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();

        // Salles disponibles seulement
        pickerSalle.ItemsSource = Salle.ListeSalles.Where(s => s.EstDisponible).ToList();

        // On ne peut pas réserver dans le passé
        datePicker.MinimumDate = DateTime.Today;
        datePicker.Date = DateTime.Today;
    }

    // Si on arrive depuis la page détail, la salle est déjà choisie
    public string SalleId
    {
        set
        {
            int id = int.Parse(value);
            Salle? salle = Salle.ListeSalles.FirstOrDefault(s => s.Id == id);
            pickerSalle.SelectedItem = salle;
        }
    }

    private async void OnConfirmerClicked(object sender, EventArgs e)
    {
        // Validation simple : on vérifie chaque champ
        bool nomOk = !string.IsNullOrWhiteSpace(entryNom.Text);
        bool salleOk = pickerSalle.SelectedItem != null;
        bool horaireOk = pickerHoraire.SelectedItem != null;

        erreurNom.IsVisible = !nomOk;
        erreurSalle.IsVisible = !salleOk;
        erreurHoraire.IsVisible = !horaireOk;

        if (!nomOk || !salleOk || !horaireOk)
        {
            return;   // on s'arrête : il y a des erreurs
        }

        Salle salle = (Salle)pickerSalle.SelectedItem;
        string horaire = (string)pickerHoraire.SelectedItem;

        Salle.NombreReservations++;

        await DisplayAlert("Réservation confirmée",
            $"Merci {entryNom.Text.Trim()} !\n{salle.Nom}\n{datePicker.Date:dd/MM/yyyy}\n{horaire}",
            "OK");

        // On vide le formulaire (rien n'est sauvegardé)
        entryNom.Text = "";
        pickerSalle.SelectedItem = null;
        pickerHoraire.SelectedItem = null;
        datePicker.Date = DateTime.Today;

        await Shell.Current.GoToAsync("//DashboardPage");
    }
}
