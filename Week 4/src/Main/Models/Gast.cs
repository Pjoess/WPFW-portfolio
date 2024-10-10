using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main;

public class Gast: Gebruiker
{
    public int id { get; set; }
    public int Credits { get; set; }
    public DateTime GeboorteDatum { get; set; }
    public DateTime EersteBezoek { get; set; }
    public List<Reservering>? Reserveringen { get; set; }
    public Attractie? Favoriet { get; set; }
    
    public GastInfo GastInfo { get; set; }
    public int GastInfoId { get; set; }
    
    public Gast? Begeleidt{ get; set; }

    protected Gast()
    {
        Email = null!;
    }

    
    public Gast(string email)
    {
        Email = email;
    }
}