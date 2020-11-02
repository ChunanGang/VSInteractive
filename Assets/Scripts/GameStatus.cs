using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatus
{
    private static int suspiciousValue;
    private static int productivity;
    public const int suspiciousValueMax = 100;
    public const int productivityMax = 100;

    public static int getSuspiciousValue()
    {
        return suspiciousValue;
    }

    public static int getProductivity()
    {
        return productivity;
    }

    public static void incrSuspicious(int incrAmout)
    {
        suspiciousValue += incrAmout;
        suspiciousValue = Mathf.Clamp(suspiciousValue, 0, suspiciousValueMax);
    }

    public static void incrProductivity(int incrAmout)
    {
        productivity += incrAmout;
        productivity = Mathf.Clamp(productivity, 0, productivityMax);
    }
}
