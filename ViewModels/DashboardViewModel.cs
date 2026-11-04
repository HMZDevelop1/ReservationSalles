using ReservationSalles.Data;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour le tableau de bord (Dashboard)
/// Affiche les statistiques relatives aux salles et réservations
/// </summary>
public class DashboardViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private int _nombreTotalSalles;
    private int _nombreSallesDisponibles;
    private int _nombreReservations;

    /// <summary>
    /// Nombre total de salles dans le système
    /// </summary>
    public int NombreTotalSalles
    {
        get => _nombreTotalSalles;
        private set => SetProperty(ref _nombreTotalSalles, value);
    }

    /// <summary>
    /// Nombre de salles actuellement disponibles pour réservation
    /// </summary>
    public int NombreSallesDisponibles
    {
        get => _nombreSallesDisponibles;
        private set => SetProperty(ref _nombreSallesDisponibles, value);
    }

    /// <summary>
    /// Nombre total de réservations effectuées
    /// </summary>
    public int NombreReservations
    {
        get => _nombreReservations;
        private set => SetProperty(ref _nombreReservations, value);
    }

    /// <summary>
    /// Constructeur qui injecte le service CarnetSalles
    /// </summary>
    /// <param name="carnetSalles">Service de gestion des salles et réservations</param>
    public DashboardViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        // S'abonner aux changements de collections
        _carnetSalles.Salles.CollectionChanged += (s, e) => ActualiserStatistiques();
        _carnetSalles.Reservations.CollectionChanged += (s, e) => ActualiserStatistiques();

        // Initialiser les statistiques
        ActualiserStatistiques();
    }

    /// <summary>
    /// Actualise toutes les statistiques affichées
    /// </summary>
    public void ActualiserStatistiques()
    {
        NombreTotalSalles = _carnetSalles.Salles.Count;
        NombreSallesDisponibles = _carnetSalles.Salles.Count(s => s.EstDisponible);
        NombreReservations = _carnetSalles.Reservations.Count;
    }
}
