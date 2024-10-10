using Microsoft.EntityFrameworkCore;

namespace Main;

[Owned]
public class DateTimeBereik
{
    public DateTime Begin { get; set; }
    public DateTime? Eind { get; set; }
    
    public bool Eindigt()
    {
        return false;
    }

    public bool Overlap(DateTimeBereik that)
    {
        return false;
    }
}