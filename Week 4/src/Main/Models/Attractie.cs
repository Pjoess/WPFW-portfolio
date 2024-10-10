using System.ComponentModel.DataAnnotations;

namespace Main;

public class Attractie
{
    public int id { get; set; }
    public string Naam { get; set; }
    
    public List<Gast> FavorieteGasten { get; set; } = new List<Gast>();
    public List<Reservering> Reserveringen { get; set; } = new List<Reservering>();
    public List<Onderhoud> Onderhouds { get; set; } = new List<Onderhoud>();
    public readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

    protected Attractie()
    {
        
    }
    public Attractie(string attractie)
    {
        Naam = attractie;
    }


    public Task<bool> OnderhoudBezig(DatabaseContext c)
    {
        return null;
    }

    public Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
    {
        return null;
    }
}