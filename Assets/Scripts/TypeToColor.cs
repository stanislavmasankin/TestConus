using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TypeToColor 
{
    public static Color GetCollor(int type) {
        if (type == 0) return new Color(1, 0, 0);
        if (type == 1) return new Color(1, 1, 0);
        if (type == 2) return new Color(1, 1, 1);
        if (type == 3) return new Color(1, 0, 1);
        if (type == 4) return new Color(0, 1, 0);
        if (type == 5) return new Color(0, 1, 1);
        if (type == 6) return new Color(0, 0, 1);
        if (type == 7) return new Color(0, 0, 0);
        if (type == 8) return new Color(1, 0.75f, 1);
        if (type == 9) return new Color(1, 1, 0.25f);
        if (type == 9) return new Color(0.4f, 0.4f, 1);
        if (type > 9) return GetCollor(type - 10) * 0.8f;
        return new Color(1, 1, 1);
    }
}
