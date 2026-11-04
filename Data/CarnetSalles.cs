using System.Collections.ObjectModel;
using ReservationSalles.Models;

namespace ReservationSalles.Data;

/// <summary>
/// Service de gestion centralisant les salles et les réservations
/// Singleton qui expose les collections observables
/// </summary>
public class CarnetSalles
{
    /// <summary>
    /// Collection de toutes les salles disponibles
    /// </summary>
    public ObservableCollection<Salle> Salles { get; }

    /// <summary>
    /// Collection de toutes les réservations effectuées
    /// </summary>
    public ObservableCollection<Reservation> Reservations { get; }

    public CarnetSalles()
    {
        Salles = new ObservableCollection<Salle>();
        Reservations = new ObservableCollection<Reservation>();

        InitialiserSalles();
        InitialiserReservations();
    }

    /// <summary>
    /// Initialise la collection avec 5 salles simulées
    /// </summary>
    private void InitialiserSalles()
    {
        var salles = new List<Salle>
        {
            new Salle
            {
                Id = 1,
                Nom = "Salle de Conférence A",
                Capacite = 50,
                Localisation = "Bâtiment A - 3ème étage",
                EstDisponible = true,
                Equipements = "Projecteur, Tableau blanc, Système audio"
            },
            new Salle
            {
                Id = 2,
                Nom = "Salle de Réunion B",
                Capacite = 20,
                Localisation = "Bâtiment B - 2ème étage",
                EstDisponible = true,
                Equipements = "Table de conférence, Écran TV 55\""
            },
            new Salle
            {
                Id = 3,
                Nom = "Amphithéâtre C",
                Capacite = 150,
                Localisation = "Bâtiment C - 1er étage",
                EstDisponible = false,
                Equipements = "Projecteur 4K, Système sonore professionnel, Estrade, Éclairage LED"
            },
            new Salle
            {
                Id = 4,
                Nom = "Salle Informatique D",
                Capacite = 30,
                Localisation = "Bâtiment A - 1er étage",
                EstDisponible = true,
                Equipements = "15 Ordinateurs, Réseau haute vitesse, Tableau interactif"
            },
            new Salle
            {
                Id = 5,
                Nom = "Atelier E",
                Capacite = 40,
                Localisation = "Bâtiment D - Rez-de-chaussée",
                EstDisponible = true,
                Equipements = "Établis, Outils de travail, Rangements"
            }
        };

        foreach (var salle in salles)
        {
            Salles.Add(salle);
        }
    }

    /// <summary>
    /// Initialise la collection avec 1 réservation simulée
    /// </summary>
    private void InitialiserReservations()
    {
        var reservation = new Reservation
        {
            Id = 1,
            SalleId = 1,
            NomUtilisateur = "Jean Dupont",
            DateReservation = DateTime.Now.AddDays(1),
            PlageHoraire = "14:00-15:30"
        };

        Reservations.Add(reservation);
    }
}
