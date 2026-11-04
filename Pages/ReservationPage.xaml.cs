using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class ReservationPage : ContentPage
{
    private readonly ReservationViewModel _viewModel;

    public ReservationPage(ReservationViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        // Liste écrite directement ici : aucune liaison nécessaire
        pickerHoraire.ItemsSource = new List<string>
        {
            "08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00",
            "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00"
        };
    }

    // Quand l'utilisateur choisit une plage, on la donne au ViewModel
    private void OnPlageChoisie(object? sender, EventArgs e)
    {
        if (pickerHoraire.SelectedItem is string plage)
        {
            _viewModel.PlageHoraire = plage;
        }
    }
}