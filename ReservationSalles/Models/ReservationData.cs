using System.Collections.Generic;

namespace ReservationSalles.Models
{
    public static class ReservationData
    {
        public static List<Salle> Salles { get; } = new List<Salle>
        {
            new Salle { Nom = "Salle 201", Capacite = 30, Localisation = "Pavillon A", Disponible = true, Image = "", Equipements = "Projecteur, Chaises" },
            new Salle { Nom = "Salle 204", Capacite = 25, Localisation = "Pavillon A", Disponible = true, Image = "", Equipements = "Tableau, Chaises" },
            new Salle { Nom = "Laboratoire informatique", Capacite = 20, Localisation = "Pavillon B", Disponible = true, Image = "", Equipements = "Ordinateurs, Réseau" }
        };

        public static int ReservationCount { get; set; } = 0;
    }
}
