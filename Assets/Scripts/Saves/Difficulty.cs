using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static int dif = 0;
    public static int Value
    {
        get { return dif; }
        set { dif = value; }
    }

    public static int GetHealthFromValue()
    {
        switch (dif)
        {
            case 0:
                return 10;
            case 1:
                return 6;
            case 2:
                return 3;
            case 3:
                return 1;
            default:
                return 10;
        }
    }
}