namespace Pretpark.Opdracht2;

public class GebruikersService
{

    public GebruikersService(IEmailService emailS, IGebruikersContext gebruikersContext)
    {
        EmailS = emailS;
        GebruikersContext = gebruikersContext;
    }
    private IEmailService EmailS { get; set; }
    private IGebruikersContext GebruikersContext { get; set; }
    
    public Gebruiker Registreer(String email, String wachtwoord)
    {
        GebruikersContext.NieuweGebruiker(wachtwoord, email);
        GebruikersContext.GetLastGebruiker();
        EmailS.Email("verificatie", email);
        
        //Email versturen ter verificatie -> USE EmailService
        //Gebruiker aangemaakt in GebruikersContext!!


        return GebruikersContext.GetLastGebruiker();
    }

    public bool Login(String email, String wachtwoord)
    {
        return !(checkAccount(email, wachtwoord) == null);
    }

    public bool Verifieer(String email, String token)
    {
        int gebruiker = 0;
        for (int i = 0; i < GebruikersContext.AantalGebruikers(); i++)
        {
            if (GebruikersContext.GetGebruiker(i).Email != email ||
                GebruikersContext.GetGebruiker(i).Vtoken.token != token) continue;


            GebruikersContext.GetGebruiker(i).Vtoken = null;
            gebruiker = i;
        }

        return GebruikersContext.GetGebruiker(gebruiker).Geverifieerd();
    }

    public Gebruiker? checkAccount(String email, String wachtwoord)
    {
        for (int i = 0; i < GebruikersContext.AantalGebruikers(); i++)
        {
            if (GebruikersContext.GetGebruiker(i).Email != email || GebruikersContext.GetGebruiker(i).Wachtwoord != wachtwoord) continue;
            Gebruiker gebruiker = GebruikersContext.GetGebruiker(i);
            return gebruiker;
        }
        
        return null;
    }
    
}