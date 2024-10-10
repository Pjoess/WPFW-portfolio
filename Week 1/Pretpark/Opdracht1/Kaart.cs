using System.Globalization;

namespace Pretpark; 

public class Kaart {
    public readonly int breedte;
    public readonly int hoogte;
    private List<Pad> paden = new List<Pad>();
    private List<KaartItem> kaartItems = new List<KaartItem>();

    public Kaart(int breedte, int hoogte) {
        this.breedte = breedte;
        this.hoogte = hoogte;
    }

    public void Teken(ITekener t) {
        foreach (var pad in paden) {
            pad.TekenConsole(new ConsoleTekener());
        }

        foreach (var item in kaartItems) {
            item.TekenConsole(new ConsoleTekener());
        }
    }

    public void VoegItemToe(KaartItem item) {
        kaartItems.Add(item);
    }

    public void VoegPadToe(Pad pad) {
        paden.Add(pad);
    }
    
    
}