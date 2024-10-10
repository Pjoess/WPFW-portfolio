using System;
using System.Security.Authentication;
using Moq;
using Pretpark.Opdracht2;

namespace TestsProject;
using Xunit;

public class GebruikersServiceTest
{
    
    // [Fact]
    // public void TestRegister()
    // {
    //     //Arrange
    //     Mock<IGebruikerService> x = new Mock<IGebruikerService>();
    //     x.Setup( t => t.Registreer(It.IsAny<string>(), It.IsAny<string>())).Returns(new Gebruiker()); 
    //     //Act
    //     //
    //     //Assert
    //     //
    // }
    // [Fact]
    // public void Register_GetLastGebruiker()
    // {
    //     //Arrange
    //     GebruikersServiceMock x = new GebruikersServiceMock();
    //     
    //     //Act
    //     var test = x.Registreer(It.IsAny<string>(), It.IsAny<string>());
    //     
    //     //Assert
    //     Assert.NotNull(test);
    // }

    // [Fact]
    // public void GebruikerssService_Registreer_GebruiktEmailService()
    // {
    //     //Arrange
    //     GebruikersService gs = new GebruikersService();
    //     IEmailService mock = new EmailServiceMock();
    //     gs.EmailS = mock;
    //     //Act
    //
    //     //Assert
    // }

    // [Fact]
    // public void GebruikersService_Emailservice_GebruiktEmail()
    // {
    //     //arrange
    //     GebruikersService gs = new GebruikersService();
    //     gs.EmailS = new EmailServiceMock();
    //     
    //     //act
    //
    //     //assert
    // }
    
    [Theory]
    [InlineData("email", "wachtwoord")]
    public void Registreer_Variabelen_Correct(string email, string wachtwoord)
    {
        //Arrange
        GebruikersContextMock gebruikerContextMock = new GebruikersContextMock();
        EmailServiceMock emailServiceMock = new EmailServiceMock();
        GebruikersService gebruikerService = new GebruikersService(emailServiceMock, gebruikerContextMock);
        //Act
        gebruikerService.Registreer(email, wachtwoord);

        //Assert
        Assert.Equal(email, gebruikerContextMock.GetLastGebruiker().Email);
        Assert.Equal(wachtwoord, gebruikerContextMock.GetLastGebruiker().Wachtwoord);
    }




    [Theory]
    [InlineData("email", "wachtwoord")]
    public void Check_GebruikersService_verifieer_UsedMethods(string email, string wachtwoord)
    {
        //Arrange
        GebruikersContextMock gebruikerContextMock = new GebruikersContextMock();
        EmailServiceMock emailServiceMock = new EmailServiceMock();
        GebruikersService gebruikerService = new GebruikersService(emailServiceMock, gebruikerContextMock);

        //Act
        gebruikerService.Registreer(email, wachtwoord);
        gebruikerContextMock.GetLastGebruiker().Vtoken = new VerificatieToken("1234", DateTime.MinValue);
        bool result = gebruikerService.Verifieer(email, "1234");
        int aantal = gebruikerContextMock.AantalGebruikers();

        //Assert
        Assert.False(result);

        //Verify correct method call
        Assert.Equal(1, aantal);
        Assert.Equal(email, gebruikerContextMock.GetLastGebruiker().Email);
    }

    [Theory]
    [InlineData("email", "wachtwoord")]
    public void testFouteLogin(string Email, string Wachtwoord)
    {
        //Arrange
        GebruikersContextMock gebruikerContextMock = new GebruikersContextMock();
        EmailServiceMock emailServiceMock = new EmailServiceMock();
        GebruikersService gebruikerService = new GebruikersService(emailServiceMock, gebruikerContextMock);
    
        //Act
        bool result = gebruikerService.Login(Email, Wachtwoord + "ldjaklfdlasfjasklfjaskl");
    
        //Assert
        Assert.False(result);
    }
    
}
