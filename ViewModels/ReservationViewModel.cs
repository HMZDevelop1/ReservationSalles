using System.Collections.ObjectModel;
using ReservationSalles.Data;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour le formulaire de réservation
/// Reçoit les infos de la salle et gère la création d'une réservation
/// </summary>
[QueryProperty(nameof(SalleId), "salleid")]
[QueryProperty(nameof(NomSalle), "nomsalle")]
public class ReservationViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private int _salleId;
    private string _nomSalle = string.Empty;
    private string _nomUtilisateur = string.Empty;
    private DateTime _dateReservation = DateTime.Now.AddDays(1);
    private string _plageHoraire = string.Empty;
    private string _messageErreur = string.Empty;

    private static int _prochainIdReservation = 2; // Commencer après la réservation simulée

    /// <summary>
    /// Identifiant de la salle à réserver (reçu via QueryProperty)
    /// </summary>
    public int SalleId
    {
        get => _salleId;
        set => SetProperty(ref _salleId, value);
    }

    /// <summary>
    /// Nom de la salle à réserver (reçu via QueryProperty)
    /// </summary>
    public string NomSalle
    {
        get => _nomSalle;
        set => SetProperty(ref _nomSalle, value ?? string.Empty);
    }

    /// <summary>
    /// Nom de l'utilisateur qui réserve
    /// </summary>
    public string NomUtilisateur
    {
        get => _nomUtilisateur;
        set => SetProperty(ref _nomUtilisateur, value ?? string.Empty);
    }

    /// <summary>
    /// Date de la réservation
    /// </summary>
    public DateTime DateReservation
    {
        get => _dateReservation;
        set => SetProperty(ref _dateReservation, value);
    }

    /// <summary>
    /// Plage horaire sélectionnée pour la réservation
    /// </summary>
    public string PlageHoraire
    {
        get => _plageHoraire;
        set => SetProperty(ref _plageHoraire, value ?? string.Empty);
    }

    /// <summary>
    /// Message d'erreur à afficher en cas de validation échouée
    /// </summary>
    public string MessageErreur
    {
        get => _messageErreur;
        set => SetProperty(ref _messageErreur, value ?? string.Empty);
    }

    /// <summary>
    /// Liste des plages horaires disponibles pour réservation
    /// </summary>
    public List<string> PlagesHoraires { get; } = new()
    {
        "08:00-09:00",
        "09:00-10:00",
        "10:00-11:00",
        "11:00-12:00",
        "12:00-13:00",
        "13:00-14:00",
        "14:00-15:00",
        "15:00-16:00",
        "16:00-17:00",
        "17:00-18:00"
    };

    /// <summary>
    /// Commande pour confirmer et créer la réservation
    /// </summary>
    public RelaisCommande ConfirmerCommand { get; }

    /// <summary>
    /// Constructeur qui injecte le service CarnetSalles
    /// </summary>
    /// <param name="carnetSalles">Service de gestion des salles et réservations</param>
    public ReservationViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        // Initialiser la commande de confirmation
        ConfirmerCommand = new RelaisCommande(
            execute: _ => ExecuterConfirmer(),
            canExecute: _ => !string.IsNullOrWhiteSpace(NomUtilisateur)
        );
    }

    /// <summary>
    /// Valide les données du formulaire et crée la réservation
    /// </summary>
    private async void ExecuterConfirmer()
    {
        // Réinitialiser le message d'erreur
        MessageErreur = string.Empty;

        // Validation du nom
        if (string.IsNullOrWhiteSpace(NomUtilisateur))
        {
            MessageErreur = "Veuillez entrer votre nom.";
            return;
        }

        // Validation de la plage horaire
        if (string.IsNullOrWhiteSpace(PlageHoraire))
        {
            MessageErreur = "Veuillez sélectionner une plage horaire.";
            return;
        }

        // Validation de la date
        if (DateReservation < DateTime.Now.Date)
        {
            MessageErreur = "La date de réservation ne peut pas être dans le passé.";
            return;
        }

        try
        {
            // Créer la nouvelle réservation
            var reservation = new Reservation
            {
                Id = _prochainIdReservation++,
                SalleId = SalleId,
                NomUtilisateur = NomUtilisateur,
                DateReservation = DateReservation,
                PlageHoraire = PlageHoraire
            };

            // Ajouter la réservation au carnet
            _carnetSalles.Reservations.Add(reservation);

            // Afficher une alerte de succès
            await Application.Current!.MainPage!.DisplayAlert(
                "Succès",
                $"Réservation confirmée pour {NomSalle} le {DateReservation:dd/MM/yyyy} de {PlageHoraire}.",
                "OK"
            );

            // Revenir à la page précédente
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            MessageErreur = $"Erreur lors de la création de la réservation: {ex.Message}";
            Console.WriteLine($"Erreur: {ex}");
        }
    }

    /// <summary>
    /// Appelé lors du changement de propriété
    /// Met à jour l'état de la commande ConfirmerCommand
    /// </summary>
    protected override void OnPropertyChanged(string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(NomUtilisateur))
        {
            ConfirmerCommand.RaiseCanExecuteChanged();
        }
    }
}
