namespace Pretpark.Opdracht2;

public class GebruikersContext : IGebruikersContext
{
    private List<Gebruiker> gebruikers = new List<Gebruiker>();
    
    public int AantalGebruikers()
    {
        return gebruikers.Count();
    }

    public Gebruiker GetGebruiker(int i)
    {
        return gebruikers[i];
    }

    public Gebruiker NieuweGebruiker(string wachtwoord, string email)
    {
        Gebruiker x = new Gebruiker(email, wachtwoord);
        gebruikers.Add(x);
        return x;
    }

    public Gebruiker GetLastGebruiker()
    {
        return gebruikers.Last();
    }
}

public interface IGebruikersContext
{
    int AantalGebruikers();
    Gebruiker GetGebruiker(int i);
    Gebruiker GetLastGebruiker();
    Gebruiker NieuweGebruiker(string wachtwoord, string email);

}


public class GebruikersContextMock: IGebruikersContext
{
    private List<Gebruiker> gebruikers = new List<Gebruiker>();
    public bool checkNieuweGebruiker { get; set; } = false;
    public int AantalGebruikers()
    {
        return gebruikers.Count();
    }

    public Gebruiker GetGebruiker(int i)
    {
        return new Gebruiker("Email", "Wachtwoord");
    }

    public Gebruiker GetLastGebruiker()
    {
        return gebruikers.Last();
    }

    public Gebruiker NieuweGebruiker(string wachtwoord, string email)
    {
        Gebruiker x = new Gebruiker(email, wachtwoord);
        gebruikers.Add(x);
        return x;
    }
}