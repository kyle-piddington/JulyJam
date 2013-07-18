using System;
using UnityEngine;

public static class helperUtil
{
    public static float upperLimit(float lower, float upper, float increment, float variable) 
    {
        if (variable >= upper)
            return upper;
        else
            return variable += increment;
    }

    public static int upperLimit(int lower, int upper, int increment, int variable)
    {
        if (variable >= upper)
            return upper;
        else
            return lower;
    }

    public static int rangeCon(float angle) 
    {
        return 1;
    }
}
