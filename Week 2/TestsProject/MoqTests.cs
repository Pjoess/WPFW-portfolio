using Xunit;
using Moq;
using Pretpark.Opdracht2;

namespace TestsProject;



public class MoqTests
{
    [Theory]
    [InlineData(true)]
    public void EmailServiceTest(bool succes)
    {
        //Arrange
        Mock<IEmailService> e = new Mock<IEmailService>();
        Mock<IGebruikersContext> g = new Mock<IGebruikersContext>();
        IEmailService es = e.Object;
        e.Setup((e) => e.Email(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        g.Setup((i) => i.NieuweGebruiker(It.IsAny<string>(), It.IsAny<string>()));
        GebruikersService gs = new GebruikersService(es, g.Object);
        //Act

        var Test = es.Email("Test", "test");
        
        //Assert
        Assert.True(Test);
    }
    
    
    // [Theory]
    // [InlineData("Email", "Wachtwoord")]
    // public void RegistreerTest(string email, string wachtwoord)
    // {
    //     //Arrange
    //     Mock<IGebruikersContext> gebruikerContext = new Mock<IGebruikersContext>();
    //     Mock<IEmailService> emailService = new Mock<IEmailService>();
    //     emailService.Setup((i) => i.Email(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
    //     gebruikerContext.Setup((i) => i.NieuweGebruiker(It.IsAny<string>(), It.IsAny<string>())).Returns(new Gebruiker(email, wachtwoord));
    //
    //     GebruikersService gebruikerService = new GebruikersService( emailService.Object, gebruikerContext.Object);
    //
    //     //Act
    //     Gebruiker gebruiker = gebruikerService.Registreer(email, wachtwoord);
    //
    //     //Assert
    //     Assert.Equal(email, gebruiker.Email);
    //     Assert.Equal(wachtwoord, gebruiker.Wachtwoord);
    // }

    [Theory]
    [InlineData("email")]
    public void testVerlopenVerificatieToken(string email)
    {
        //Arrange
        Mock<IGebruikersContext> gebruikerContext = new Mock<IGebruikersContext>();
        Mock<IEmailService> emailService = new Mock<IEmailService>();
        Gebruiker gebruiker = new Gebruiker(email, "ww");
        gebruiker.Vtoken = new VerificatieToken();
        gebruikerContext.Setup((i) => i.GetGebruiker(0)).Returns(gebruiker);
    
        GebruikersService gebruikerService = new GebruikersService(emailService.Object, gebruikerContext.Object);
    
        //Act
        bool result = gebruikerService.Verifieer(email, "1234");
    
        //Assert
        Assert.False(result);
        gebruikerContext.Verify((i) => i.GetGebruiker(0), Times.Once());
    }
    
    [Theory]
    [InlineData("email", "wachtwoord")]
    [InlineData("email2", "wachtwoord")]
    public void testFouteLogin(string Email, string Wachtwoord)
    {
        //Arrange
        
        Mock<IGebruikersContext> gebruikerContext = new Mock<IGebruikersContext>();
        Mock<IEmailService> emailService = new Mock<IEmailService>();
        gebruikerContext.Setup((i) => i.NieuweGebruiker(It.IsAny<string>(), It.IsAny<string>())).Returns(new Gebruiker(Email, Wachtwoord));

        var gc = gebruikerContext.Object;
        GebruikersService gebruikerService = new GebruikersService(emailService.Object, gc);
        
        //Act
        gebruikerService.Registreer("Tim", "ww");
        bool result = gebruikerService.Login(Email, Wachtwoord);
    
        //Assert
        Assert.False(result);
    }
}