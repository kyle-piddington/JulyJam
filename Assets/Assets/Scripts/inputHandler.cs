using System;
using UnityEngine;

public static class inputHandler
{
    public static bool keyHandler(KeyCode key)
    {
        return Input.GetKey(key); 
    }
	
}
