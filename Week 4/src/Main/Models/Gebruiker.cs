using System.ComponentModel.DataAnnotations.Schema;

namespace Main;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Gebruiker
{
    public int id { get; set; }
    public string Email { get; set; }

    protected Gebruiker()
    {
        this.Email = null!;
    }
    protected Gebruiker(string email)
    {
        this.Email = email;
    }
}