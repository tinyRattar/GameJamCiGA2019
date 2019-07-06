using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    None = 0,
    Fire = 1,
    Ice = 2,
    Wind = 3
}

public static class Util
{
    static float[][] gridElementEffect = new float[][]{
        new float[] { -1, 0, 1 },
        new float[] { 1, -1, 0 },
        new float[] { 0, 1, -1 },
    };

    public static float CalcElementEffect(ElementType src, ElementType tar)
    {
        if (src == ElementType.None || tar == ElementType.None)
            return 1f;
        else
            return gridElementEffect[(int)src][(int)tar];
    }

}
