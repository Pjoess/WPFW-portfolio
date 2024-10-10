using System.Threading.Tasks.Dataflow;

namespace Pretpark; 

public class Pad : ITekenbaar {
    private float? lengteBerekend;
    private Coordinaat van;
    private Coordinaat naar;


    public float? Lengte()
    {
        if (lengteBerekend == null) {
            var verschil = naar - van;
            lengteBerekend = (float)Math.Sqrt(verschil.x * verschil.x + verschil.y + verschil.y);
        }

        return lengteBerekend;
    }

    public void TekenConsole(ConsoleTekener t) {
        var verschil = naar - van;
        for (int i = 0; i < 100; i++) {
            if (true)
            {
                t.SchrijfOp(van + new Coordinaat((int)(verschil.x * ((float)i / 100)), (int)(verschil.y * ((float)i / 100))),"#");
            }
            else
            {
                // t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * .5), (int)Math.Round(van.y + (naar.y - van.y) * .5))("#"));
            }
            
        } 
    }
    
    public Coordinaat Van {
        get {
            return van;
        }
        set {
            van = value;
            lengteBerekend = null;
        }
    }

    public Coordinaat Naar {
        get {
            return naar;
        }
        set {
            naar = value;
        }
    }

}