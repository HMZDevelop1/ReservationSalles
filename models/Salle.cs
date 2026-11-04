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
}











































































