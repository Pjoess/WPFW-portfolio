namespace Pretpark; 

public class ConsoleTekener : ITekener {
    public void Teken(ITekenbaar t) {
        
    }
    
    public void SchrijfOp(Coordinaat Positie, string Text) {
        if (Positie.x < 0 || Positie.y < 0)
            throw new Exception("Kan niet tekenen in het negatieve!");
        Console.SetCursorPosition(Positie.x, Positie.y);
        Console.WriteLine(Text);
    }
}