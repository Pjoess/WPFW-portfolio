namespace Pretpark.Opdracht2;

public class Gebruiker
{
    public String Wachtwoord { get; set; }
    public String Email { get; set; }

    public VerificatieToken Vtoken { get; set; }
    // private String Naam { get; set; }

    public Gebruiker(String Email, String Wachtwoord)
    {
        this.Email = Email;
        this.Wachtwoord = Wachtwoord;
        Vtoken = new VerificatieToken();
    }
    public Boolean Geverifieerd()
    {
        if (Vtoken == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}