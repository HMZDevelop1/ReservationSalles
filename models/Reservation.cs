namespace ReservationSalles.Models;

/// <summary>
/// Représente une réservation de salle
/// </summary>
public class Reservation
{
    /// <summary>
    /// Identifiant unique de la réservation
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Identifiant de la salle réservée
    /// </summary>
    public int SalleId { get; set; }

    /// <summary>
    /// Nom de l'utilisateur qui a fait la réservation
    /// </summary>
    public string NomUtilisateur { get; set; } = string.Empty;

    /// <summary>
    /// Date de la réservation
    /// </summary>
    public DateTime DateReservation { get; set; }

    /// <summary>
    /// Plage horaire de la réservation (ex: "09:00-10:00")
    /// </summary>
    public string PlageHoraire { get; set; } = string.Empty;
}
