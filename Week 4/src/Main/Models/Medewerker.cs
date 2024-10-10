using System.ComponentModel.DataAnnotations;

namespace Main;

public class Medewerker: Gebruiker
{
    public int id { get; set; }
    
    public List<Onderhoud> doetOnderhoud { get; set; }
    public List<Onderhoud> doetCoordinatie { get; set; }

    protected Medewerker(): base()
    {
        Email = null!;
    }
    public Medewerker(string email): base(email)
    {
        Email = email;
    }
}