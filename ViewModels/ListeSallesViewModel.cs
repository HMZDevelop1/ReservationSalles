using System.Collections.ObjectModel;
using ReservationSalles.Data;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour la liste des salles
/// Permet la sélection d'une salle et la navigation vers ses détails
/// </summary>
public class ListeSallesViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private Salle? _salleSelectionnee;

    /// <summary>
    /// Collection de toutes les salles disponibles
    /// </summary>
    public ObservableCollection<Salle> Salles => _carnetSalles.Salles;

    /// <summary>
    /// Salle actuellement sélectionnée par l'utilisateur
    /// </summary>
    public Salle? SalleSelectionnee
    {
        get => _salleSelectionnee;
        set => SetProperty(ref _salleSelectionnee, value);
    }

    /// <summary>
    /// Commande pour afficher les détails de la salle sélectionnée
    /// </summary>
    public RelaisCommande VoirDetailCommand { get; }

    /// <summary>
    /// Constructeur qui injecte le service CarnetSalles
    /// </summary>
    /// <param name="carnetSalles">Service de gestion des salles et réservations</param>
    public ListeSallesViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        // Initialiser la commande
        VoirDetailCommand = new RelaisCommande(
            execute: _ => ExecuterVoirDetail(),
            canExecute: _ => SalleSelectionnee is not null
        );
    }

    /// <summary>
    /// Navigue vers la page de détail de la salle sélectionnée
    /// </summary>
    private async void ExecuterVoirDetail()
    {
        if (SalleSelectionnee is null)
            return;

        try
        {
            // Navigation avec Shell - passer la salle en paramètre de query
            await Shell.Current.GoToAsync($"detailsalle?salle={SalleSelectionnee.Id}");
        }
        catch (Exception ex)
        {
            // Log ou gestion d'erreur
            Console.WriteLine($"Erreur lors de la navigation: {ex.Message}");
        }
    }

    /// <summary>
    /// Appelé lors de la sélection d'une salle
    /// Met à jour l'état de la commande VoirDetailCommand
    /// </summary>
    protected override void OnPropertyChanged(string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(SalleSelectionnee))
        {
            // Rafraîchir l'état de la commande
            VoirDetailCommand.RaiseCanExecuteChanged();
        }
    }
}
