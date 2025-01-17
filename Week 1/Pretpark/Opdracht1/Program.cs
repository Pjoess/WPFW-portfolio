namespace Pretpark;

public class Program {
    
    public static void Main(string[] args) {
        Kaart k = new Kaart(30, 30);
        Pad p1 = new Pad();
        p1.Van = new Coordinaat(2, 5);
        p1.Van = new Coordinaat(12, 30);
        k.VoegPadToe(p1);
        Pad p2 = new Pad();
        p2.Van = new Coordinaat(26, 4);
        p2.Naar = new Coordinaat(10, 5);
        k.VoegPadToe(p2);
        k.VoegItemToe(new KaartItem(k, new Coordinaat(15, 15)));
        k.VoegItemToe(new KaartItem(k, new Coordinaat(20, 15)));
        k.VoegItemToe(new KaartItem(k, new Coordinaat(5, 18)));
        k.Teken(new ConsoleTekener());
        new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.hoogte + 1), "Deze kaart is schaal 1:1000");
        Console.Read();
    }
}