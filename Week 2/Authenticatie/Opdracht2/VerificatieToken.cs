using System.Security.Cryptography;

namespace Pretpark.Opdracht2;

public class VerificatieToken
{
    public String token { get; set; }
    private DateTime verloopDatum { get; set; }
    private int number;

    public VerificatieToken(string token, DateTime time)
    {
        this.token = token;
        this.verloopDatum = time;
    }
    public VerificatieToken()
    {
        token = RandomNumber();
        verloopDatum = DateTime.Now;
    }

    public String RandomNumber()
    {
        number++;
        return number.ToString();
    }
}