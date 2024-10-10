namespace Pretpark; 

public class KaartItem : ITekenbaar {
    private Kaart kaart;
    private Coordinaat _locatie;
    private char karakter;


    public KaartItem(Kaart kaart, Coordinaat locatie) {
        this.kaart = kaart;
        this._locatie = locatie;
    }

    public void TekenConsole(ConsoleTekener t) {
        t.SchrijfOp(_locatie,"A");
    }

    // public Coordinaat Locatie
    // {
    //     get { return Locatie;} 
    //     set{
    //         if (kaart.breedte >= _locatie.x)
    //         {
    //             Locatie = value;
    //         }
    //     }
    // }

    public char Karakter {
        get;
    }
}