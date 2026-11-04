using ReservationSalles.ViewModels;

namespace ReservationSalles.Pages;

public partial class ReservationPage : ContentPage
{
    public ReservationPage(ReservationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
