using System.ComponentModel.DataAnnotations;

namespace Main;

public class Onderhoud
{
    public int id { get; set; }
    public string Probleem { get; set; }
    public Attractie Attractie { get; set; }
    
    public List<Medewerker> onderhoudGedaan { get; set; }
    public List<Medewerker> coordinatieGedaan { get; set; }
    public DateTimeBereik DateTimeBereik { get; set; }
    
}