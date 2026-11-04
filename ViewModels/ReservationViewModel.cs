using System.Collections.ObjectModel;
using ReservationSalles.Data;
using ReservationSalles.Models;

namespace ReservationSalles.ViewModels;

/// <summary>
/// ViewModel pour le formulaire de réservation
/// Reçoit les infos de la salle et gère la création d'une réservation
/// </summary>
[QueryProperty(nameof(SalleId), "SalleId")]
[QueryProperty(nameof(NomSalle), "NomSalle")]
public class ReservationViewModel : ViewModelBase
{
    private readonly CarnetSalles _carnetSalles;
    private int _salleId;
    private string _nomSalle = string.Empty;
    private string _nomUtilisateur = string.Empty;
    private DateTime _dateReservation = DateTime.Now.AddDays(1);
    private string _plageHoraire = string.Empty;
    private string _messageErreur = string.Empty;

    private static int _prochainIdReservation = 2;

    public int SalleId
    {
        get => _salleId;
        set => SetProperty(ref _salleId, value);
    }

    public string NomSalle
    {
        get => _nomSalle;
        set => SetProperty(ref _nomSalle, value ?? string.Empty);
    }

    public string NomUtilisateur
    {
        get => _nomUtilisateur;
        set => SetProperty(ref _nomUtilisateur, value ?? string.Empty);
    }

    public DateTime DateReservation
    {
        get => _dateReservation;
        set => SetProperty(ref _dateReservation, value);
    }

    public string PlageHoraire
    {
        get => _plageHoraire;
        set => SetProperty(ref _plageHoraire, value ?? string.Empty);
    }

    public string MessageErreur
    {
        get => _messageErreur;
        set => SetProperty(ref _messageErreur, value ?? string.Empty);
    }

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

    public RelaisCommande ConfirmerCommand { get; }

    public ReservationViewModel(CarnetSalles carnetSalles)
    {
        _carnetSalles = carnetSalles ?? throw new ArgumentNullException(nameof(carnetSalles));

        ConfirmerCommand = new RelaisCommande(
            execute: _ => ExecuterConfirmer(),
            canExecute: _ => !string.IsNullOrWhiteSpace(NomUtilisateur)
        );
    }

    private async void ExecuterConfirmer()
    {
        MessageErreur = string.Empty;

        if (string.IsNullOrWhiteSpace(NomUtilisateur))
        {
            MessageErreur = "Veuillez entrer votre nom.";
            return;
        }

        if (string.IsNullOrWhiteSpace(PlageHoraire))
        {
            MessageErreur = "Veuillez sélectionner une plage horaire.";
            return;
        }

        if (DateReservation < DateTime.Now.Date)
        {
            MessageErreur = "La date de réservation ne peut pas être dans le passé.";
            return;
        }

        try
        {
            var reservation = new Reservation
            {
                Id = _prochainIdReservation++,
                SalleId = SalleId,
                NomUtilisateur = NomUtilisateur,
                DateReservation = DateReservation,
                PlageHoraire = PlageHoraire
            };

            _carnetSalles.Reservations.Add(reservation);

            await Application.Current!.MainPage!.DisplayAlert(
                "Succès",
                $"Réservation confirmée pour {NomSalle} le {DateReservation:dd/MM/yyyy} de {PlageHoraire}.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            MessageErreur = $"Erreur lors de la création de la réservation: {ex.Message}";
        }
    }

    protected override void OnPropertyChanged(string propertyName = "")
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(NomUtilisateur))
        {
            ConfirmerCommand.RaiseCanExecuteChanged();
        }
    }
}
