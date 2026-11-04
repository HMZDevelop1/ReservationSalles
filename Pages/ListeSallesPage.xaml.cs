using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class ListeSallesPage : ContentPage
{
    public ListeSallesPage(ListeSallesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    // Quand on revient sur la liste, on enlève la sélection précédente
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListeSallesViewModel viewModel)
        {
            viewModel.SalleSelectionnee = null;
        }
    }
}
