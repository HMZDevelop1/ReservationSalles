using TonProjet.Models;
namespace TonProjet.Pages;

[QueryProperty(nameof(Salle), "Salle")]public partial class ReservationPage : ContentPage{
    private Salle salle;

    public Salle Salle    {
        get => salle;
        set        {
            salle = value;

            if (salle != null && SallePicker != null)
            {
                SallePicker.SelectedItem = salle.Nom;
            }
        }
    }

    public ReservationPage()
    {
        InitializeComponent();

        DatePickerReservation.MinimumDate = DateTime.Today;
        DatePickerReservation.Date = DateTime.Today;
    }

    private async void OnConfirmerClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NomEntry.Text))
        {
            await DisplayAlert(
                "Erreur",
                "Veuillez entrer votre nom.",
                "OK");

            return;
        }

        if (HorairePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Erreur",
                "Veuillez choisir une plage horaire.",
                "OK");

            return;
        }

        if (SallePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Erreur",
                "Veuillez choisir une salle.",
                "OK");

            return;
        }

        await DisplayAlert(
            "Réservation confirmée",
            $"Réservation de {SallePicker.SelectedItem} pour {NomEntry.Text}.",
            "OK");

        await Shell.Current.GoToAsync("//DashboardPage");
    }

    private async void OnAnnulerClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
