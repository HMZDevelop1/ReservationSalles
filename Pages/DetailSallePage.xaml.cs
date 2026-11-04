using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class DetailSallePage : ContentPage
{
    public DetailSallePage(DetailSalleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");   // ".." = retour à la page précédente
    }
}
