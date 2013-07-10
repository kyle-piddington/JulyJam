using UnityEngine;
using System.Collections;

public class ScreenBounds{

    public static int x = -53;
    public static int z = 30;
    public static int width = 106;
    public static int height=60;

    public static bool Contains(Vector2 point)
    {
        return (point.x > x && point.y < z && point.x < x + width && point.y > z - height);
    }
}
