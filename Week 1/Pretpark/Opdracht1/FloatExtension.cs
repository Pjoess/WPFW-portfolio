namespace Pretpark; 

public static class FloatExtension {
    public static string metSuffixen(this float f) {
        if (f / 1000000000 > 1) {
            return f/1000000000 + "B";
        } else if (f / 1000000 > 1) {
            return f / 1000000 + "M";
        } else if (f/1000 > 1) {
            return f / 1000 + "K";
        } else {
            return f + "";
        }
    }
}