using System.ComponentModel.DataAnnotations;

namespace Main;

public class GastInfo
{
    public int id { get; set; }
    public int? ForeignKey { get; set; }
    public string LaaststBezochteURL { get; set; }
    public Gast Gast { get; set; }
    public Coordinate coordinaat { get; set; }
    
}