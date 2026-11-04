using ReservationSalles.Data;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour l'affichage des détails d'une salle
/// Reçoit la salle via les paramètres de query et permet de réserver
/// </summary>
[QueryProperty(nameof(SalleId), "salle")]
public class DetailSalleViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private int _salleId;
    private Salle? _salle;

    /// <summary>
    /// Identifiant de la salle (reçu via QueryProperty)
    /// </summary>
    public int SalleId
    {
        get => _salleId;
        set
        {
            if (SetProperty(ref _salleId, value))
            {
                ChargerSalle();
            }
        }
    }

    /// <summary>
    /// La salle dont on affiche les détails
    /// </summary>
    public Salle? Salle
    {
        get => _salle;
        private set => SetProperty(ref _salle, value);
    }

    /// <summary>
    /// Texte concaténé des équipements (formaté pour l'affichage)
    /// </summary>
    public string EquipementsText
    {
        get
        {
            if (Salle is null || string.IsNullOrWhiteSpace(Salle.Equipements))
                return "Aucun équipement";

            return Salle.Equipements;
        }
    }

    /// <summary>
    /// Commande pour réserver la salle
    /// </summary>
    public RelaisCommande ReserverCommand { get; }

    /// <summary>
    /// Constructeur qui injecte le service CarnetSalles
    /// </summary>
    /// <param name="carnetSalles">Service de gestion des salles et réservations</param>
    public DetailSalleViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        // Initialiser la commande
        ReserverCommand = new RelaisCommande(
            execute: _ => ExecuterReserver(),
            canExecute: _ => Salle is not null
        );
    }

    /// <summary>
    /// Charge la salle depuis le CarnetSalles en utilisant SalleId
    /// </summary>
    private void ChargerSalle()
    {
        Salle = _carnetSalles.Salles.FirstOrDefault(s => s.Id == SalleId);
        OnPropertyChanged(nameof(EquipementsText));
        ReserverCommand.RaiseCanExecuteChanged();
    }

    /// <summary>
    /// Navigue vers la page de réservation en passant les infos de la salle
    /// </summary>
    private async void ExecuterReserver()
    {
        if (Salle is null)
            return;

        try
        {
            // Navigation avec Shell - passer SalleId et NomSalle en paramètres
            await Shell.Current.GoToAsync($"reservation?salleid={Salle.Id}&nomsalle={Uri.EscapeDataString(Salle.Nom)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la navigation vers réservation: {ex.Message}");
        }
    }

    /// <summary>
    /// Appelé quand le ViewModel est créé/réutilisé
    /// Utile pour rafraîchir les données si nécessaire
    /// </summary>
    public void Actualiser()
    {
        if (SalleId > 0)
        {
            ChargerSalle();
        }
    }
}
