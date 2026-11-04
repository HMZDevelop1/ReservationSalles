using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class DashboardPage : ContentPage
{
    // Le ViewModel est fourni automatiquement (injection de dépendances, voir MauiProgram)
    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnListeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ListeSallesPage");
    }
}
