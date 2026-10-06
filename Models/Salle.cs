namespace ReservationSalles.Models
{
    public class Salle
    {
        public string Nom { get; set; }
        public int Capacite { get; set; }
        public string Localisation { get; set; }
        public bool Disponible { get; set; }
        public string Image { get; set; }
        public string Equipements { get; set; }
    }
}
