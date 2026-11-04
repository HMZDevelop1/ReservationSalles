using ReservationSalles.Models;
using ReservationSalles.Data;
using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

[QueryProperty(nameof(SalleId), "salleId")]
public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();

        var carnet = new CarnetSalles();
        pickerSalle.ItemsSource = carnet.Salles.Where(s => s.EstDisponible).ToList();

        datePicker.MinimumDate = DateTime.Today;
        datePicker.Date = DateTime.Today;
    }

    public string SalleId
    {
        set
        {
            int id = int.Parse(value);
            var carnet = new CarnetSalles();
            Salle? salle = carnet.Salles.FirstOrDefault(s => s.Id == id);
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
