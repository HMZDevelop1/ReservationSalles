using ReservationSalles.Data;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour l'affichage des détails d'une salle
/// Reçoit la salle via les paramètres de query et permet de réserver
/// </summary>
[QueryProperty(nameof(Salle), "Salle")]
public class DetailSalleViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private Salle? _salle;

    public Salle? Salle
    {
        get => _salle;
        set
        {
            if (SetProperty(ref _salle, value))
            {
                OnPropertyChanged(nameof(EquipementsText));
                ReserverCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string EquipementsText
    {
        get
        {
            if (Salle is null || Salle.Equipements == null || Salle.Equipements.Count == 0)
                return "Aucun équipement";

            return string.Join(", ", Salle.Equipements);
        }
    }

    public int SalleId => Salle?.Id ?? 0;
    public string NomSalle => Salle?.Nom ?? string.Empty;

    public RelaisCommande ReserverCommand { get; }

    public DetailSalleViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        ReserverCommand = new RelaisCommande(
            execute: _ => ExecuterReserver(),
            canExecute: _ => Salle is not null
        );
    }

    private async void ExecuterReserver()
    {
        if (Salle is null)
            return;

        try
        {
            await Shell.Current.GoToAsync(
                "ReservationPage",
                new Dictionary<string, object>
                {
                    ["SalleId"] = Salle.Id,
                    ["NomSalle"] = Salle.Nom
                });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la navigation vers réservation: {ex.Message}");
        }
    }
}

