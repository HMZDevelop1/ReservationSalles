namespace ReservationSalles;

// Une salle, avec ses données simulées directement dans le code
public class Salle
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public int Capacite { get; set; }
    public string Localisation { get; set; } = "";
    public bool EstDisponible { get; set; }
    public string Equipements { get; set; } = "";
    public string Description { get; set; } = "";

    // Texte et couleur affichés selon la disponibilité
    public string TexteDisponibilite
    {
        get { return EstDisponible ? "Disponible" : "Occupée"; }
    }

    public Color CouleurDisponibilite
    {
        get { return EstDisponible ? Colors.Green : Colors.Red; }
    }

    public string TexteCapacite
    {
        get { return Capacite + " personnes"; }
    }

    // ===== Données simulées =====
    public static int NombreReservations = 5;

    public static List<Salle> ListeSalles = new List<Salle>
    {
        new Salle { Id = 1, Nom = "Salle A101", Capacite = 30, Localisation = "Bâtiment A, 1er étage",
                    EstDisponible = true, Equipements = "Projecteur, Tableau blanc, Wi-Fi",
                    Description = "Grande salle de cours lumineuse, idéale pour les présentations." },
        new Salle { Id = 2, Nom = "Salle B205", Capacite = 12, Localisation = "Bâtiment B, 2e étage",
                    EstDisponible = true, Equipements = "Écran TV, Visioconférence, Wi-Fi",
                    Description = "Salle de réunion pour les petites équipes." },
        new Salle { Id = 3, Nom = "Laboratoire C010", Capacite = 24, Localisation = "Bâtiment C, rez-de-chaussée",
                    EstDisponible = false, Equipements = "24 ordinateurs, Projecteur, Wi-Fi",
                    Description = "Laboratoire informatique équipé de postes de travail." },
        new Salle { Id = 4, Nom = "Salle D300", Capacite = 60, Localisation = "Bâtiment D, 3e étage",
                    EstDisponible = true, Equipements = "Scène, Micro, Projecteur, Système de son",
                    Description = "Salle de conférence pour les grands événements." },
        new Salle { Id = 5, Nom = "Salle E112", Capacite = 8, Localisation = "Bâtiment E, 1er étage",
                    EstDisponible = false, Equipements = "Tableau blanc, Wi-Fi",
                    Description = "Petite salle calme pour le travail d'équipe." }
    };
}
