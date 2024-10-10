using System.ComponentModel.DataAnnotations;

namespace Main;

public class Reservering
{
    public int id { get; set; }
    public Gast? gast { get; set; }
    public DateTimeBereik DateTimeBereik { get; set; }
    public Attractie Attractie { get; set; }
    

}