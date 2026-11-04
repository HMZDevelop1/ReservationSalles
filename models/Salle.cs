namespace ReservationSalles.Models;

public class Salle
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public int Capacite { get; set; }
    public string Localisation { get; set; } = string.Empty;
    public bool EstDisponible { get; set; }
    public List<string> Equipements { get; set; } = new();
    public string Description { get; set; } = string.Empty;

    public string TexteDisponibilite => EstDisponible ? "Disponible" : "Occupée";

    public Color CouleurDisponibilite => EstDisponible ? Colors.Green : Colors.Red;

    public string TexteCapacite => $"{Capacite} personnes";

    public static List<Salle> ListeSalles = new()
    {
        new Salle
        {
            Id = 1,
            Nom = "Salle A101",
            Capacite = 30,
            Localisation = "Bâtiment A, 1er étage",
            EstDisponible = true,
            Equipements = new List<string> { "Projecteur", "Tableau blanc", "Wi-Fi" },
            Description = "Grande salle de cours lumineuse, idéale pour les présentations."
        },
        new Salle
        {
            Id = 2,
            Nom = "Salle B205",
            Capacite = 12,
            Localisation = "Bâtiment B, 2e étage",
            EstDisponible = true,
            Equipements = new List<string> { "Écran TV", "Visioconférence", "Wi-Fi" },
            Description = "Salle de réunion pour les petites équipes."
        },
        new Salle
        {
            Id = 3,
            Nom = "Laboratoire C010",
            Capacite = 24,
            Localisation = "Bâtiment C, rez-de-chaussée",
            EstDisponible = false,
            Equipements = new List<string> { "Ordinateurs", "Projecteur", "Wi-Fi" },
            Description = "Laboratoire informatique équipé de postes de travail."
        },
        new Salle
        {
            Id = 4,
            Nom = "Salle D300",
            Capacite = 60,
            Localisation = "Bâtiment D, 3e étage",
            EstDisponible = true,
            Equipements = new List<string> { "Scène", "Micro", "Projecteur", "Système de son" },
            Description = "Salle de conférence pour les grands événements."
        },
        new Salle
        {
            Id = 5,
            Nom = "Salle E112",
            Capacite = 8,
            Localisation = "Bâtiment E, 1er étage",
            EstDisponible = false,
            Equipements = new List<string> { "Tableau blanc", "Wi-Fi" },
            Description = "Petite salle calme pour le travail d'équipe."
        }
    };
}






























