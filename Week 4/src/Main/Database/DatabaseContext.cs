using System.Collections.Immutable;
using Main;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{

    //Database sets
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Gast> Gasten { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }
    public DbSet<Onderhoud> Onderhoud { get; set; }
    public DbSet<Attractie> Attracties { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite(@"Data Source=db1.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //
        //
        modelBuilder.Entity<GastInfo>().HasOne(gi => gi.Gast).WithOne(g => g.GastInfo)
            .HasForeignKey<GastInfo>(g => g.ForeignKey);
        modelBuilder.Entity<Gast>().ToTable("Gast");
        modelBuilder.Entity<Medewerker>().ToTable("Medewerker");
        modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
        
        modelBuilder.Entity<GastInfo>().OwnsOne(g => g.coordinaat);
        
        modelBuilder.Entity<Reservering>().OwnsOne(r => r.DateTimeBereik);
        modelBuilder.Entity<Onderhoud>().OwnsOne(o => o.DateTimeBereik);
        
        modelBuilder.Entity<Medewerker>()
            .HasMany<Onderhoud>(m => m.doetOnderhoud)
            .WithMany(o => o.onderhoudGedaan);

        modelBuilder.Entity<Onderhoud>()
            .HasMany<Medewerker>(o => o.coordinatieGedaan)
            .WithMany(m => m.doetCoordinatie);
        // modelBuilder.Entity<Gast>()
        //     .HasOne<GastInfo>(g => g.GastInfo)
        //     .WithOne(gi => gi.Gast);
    }
    
    // public async Task<bool> Boek(Gast gast, Attractie attractie, DateTimeBereik datum)
    // {
    //     if (gast == null || attractie == null || datum == null) return false;
    //
    //     await attractie.Semaphore.WaitAsync();
    //     using var transaction = Database.BeginTransaction();
    //     try
    //     {
    //         if (!await attractie.Vrij(this, datum)) return false;
    //
    //         var reservering = new Reservering
    //         {
    //             Gast = gast,
    //             Attractie = attractie,
    //             Tijd = datum
    //         };
    //         gast.Credits--;
    //
    //         gast.Reserveringen.Add(reservering);
    //         Reserveringen.Add(reservering);
    //         await SaveChangesAsync();
    //         transaction.Commit();
    //
    //     }
    //     finally { attractie.Semaphore.Release(); }
    //     return true;
    // }
}
