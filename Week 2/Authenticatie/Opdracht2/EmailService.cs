namespace Pretpark.Opdracht2;

public interface IEmailService
{
    bool Email(string tekst, string naarAdres);
}

public class EmailServiceMock : IEmailService
{
    public bool email = false;
    
    public bool Email(string tekst, string naarAdres)
    {
        email = true;
        return email;
    }
}
public class EmailService : IEmailService
{
    
    public EmailService(){}
    public bool Email(string tekst, string naarAdres)
    {
        Console.WriteLine(naarAdres);
        Console.WriteLine(tekst);
        Console.ReadLine();
        return true;
    }
}