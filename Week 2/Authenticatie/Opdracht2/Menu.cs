namespace Pretpark.Opdracht2;

public class Menu
{
    
    private Gebruiker? gebruiker;
    private GebruikersService service = new GebruikersService(new EmailService(), new GebruikersContext());
    public Menu()
    {
        startMenu();
    }

    public void startMenu()
    {
        Console.WriteLine("1- Registreren");
        Console.WriteLine("2- Inloggen");
        
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                Registreer();
                break;
            case 2:
                Login();
                break;
        }
    }
    public void Registreer()
    {
        Console.WriteLine("Geef uw email: ");
        String email = Console.ReadLine();
        Console.WriteLine("Geef uw wachtwoord: ");
        String wachtwoord = Console.ReadLine();
        
        gebruiker = service.Registreer(email, wachtwoord);
        startMenu();
    }

    public void Login()
    {
        
        Console.WriteLine("Geef uw email en wachtwoord: ");
        var email = Console.ReadLine();
        var wachtwoord = Console.ReadLine();

        if (!service.Login(email, wachtwoord))
        {
            if (service.checkAccount(email, wachtwoord).Geverifieerd())
            {
                Console.WriteLine("Welkom");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Voer uw VerificatieCode in:");
                var token = Console.ReadLine();
                if (!service.Verifieer(email, token))
                {
                    Console.WriteLine("Code is incorrect...");
                }
                else
                {
                    Console.WriteLine("U kunt nu inloggen...");
                    startMenu();
                }

            }
        }
        else
        {
            Console.WriteLine("Account bestaat niet/wachtwoord is incorrect...");
            Login();
            
            
        }
            
        

        service.Login(email, wachtwoord);
        
    }
}