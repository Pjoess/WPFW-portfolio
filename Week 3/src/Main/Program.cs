using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBoekOpdracht
{
    class Boek
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public float AIScore {
            get {
                // Deze 'berekening' is eigenlijk een ingewikkeld AI algoritme.
                // Pas de volgende vier regels niet aan.
                double ret = 1.0f;
                for (int i = 0; i < 10000000; i++)
                    for (int j = 0; j < 10; j++)
                        ret = (ret + Willekeurig.Random.NextDouble()) % 1.0;
                return (float)ret;
            }
        }
    }
    static class Willekeurig
    {
        public static Random Random = new Random();
        public static async Task Vertraging(int MinAantalMs = 500, int MaxAantalMs = 1000)
        {
            await Task.Delay(Random.Next(MinAantalMs, MaxAantalMs));
        }
    }
    static class Database
    {
        private static List<Boek> lijst = new List<Boek>();
        public static void VoegToe(Boek b)
        {
            // INSERT INTO ...
            lijst.Add(b);
        }
        public static async Task<List<Boek>> HaalLijstOp()
        { 
            // SELECT * FROM ...
            return lijst;
        }
        public static async void Logboek(string melding)
        {
            await Willekeurig.Vertraging(); // schrijf naar logbestand
        }
    }
    class Program
    {
        static async void VoegBoekToe() {
            Console.WriteLine("Geef de titel op: ");
            var titel = Console.ReadLine();
            Console.WriteLine("Geef de auteur op: ");
            var auteur = Console.ReadLine();
            var t = Database.VoegToe(new Boek {Titel = titel, Auteur = auteur});
            var t2 = Database.Logboek("Er is een nieuw boek!");
            await t;
            await t2
            Console.WriteLine("De huidige lijst met boeken is: ");
            foreach (var boek in await Database.HaalLijstOp()) {
                Console.WriteLine(boek.Titel);
            }
        }
        static async Task ZoekBoek() {
            Console.WriteLine("Waar gaat het boek over?");
            var beschrijving = Console.ReadLine();
            Boek beste = null;
            foreach (var boek in await Database.HaalLijstOp())
                if (beste == null || boek.AIScore > beste.AIScore)
                    beste = boek;
            Console.WriteLine("Het boek dat het beste overeenkomt met de beschrijving is: ");
            Console.WriteLine(beste.Titel);
        }
        static bool Backupping = false;

        public static bool B = false;
        // "Backup" kan lang duren. We willen dat de gebruiker niet hoeft te wachten,
        // en direct daarna boeken kan toevoegen en zoeken.
        static async Task Backup()
        {
            if (Backupping)
            {
                return;
            }

            Backupping = true;
            // await Willekeurig.Vertraging();
            Backupping = false;
            
            // Backupping = true;
            // while (Backupping)
            // {
            // Console.WriteLine("Backupping........");
            // if (!B)
            // {
            // Console.WriteLine("Stoppen backup = x");
            // String test = Console.ReadLine();
            // if (test.Equals("x"))
            // {
            // Backupping = false;
            // return;
            // }
            // }
            // }
        }
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welkom bij de boeken administratie!");
            string key = null;
            while (key != "q") {
                Console.WriteLine("+) Boek toevoegen");
                Console.WriteLine("z) Boek zoeken");
                Console.WriteLine("b) Backup maken van de boeken");
                Console.WriteLine("q) Quit");
                key = Console.ReadLine();
                if (key == "+")
                {
                    VoegBoekToe();
                }
                else if (key == "z")
                {
                    ZoekBoek();
                }
                else if (key == "b")
                {
                    Backup();
                }
                else Console.WriteLine("Ongeldige invoer!");
            }
            
        }
    }
}