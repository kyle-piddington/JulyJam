using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playerManager{
    private static GameObject player;
    private static shipRotation playerShipDodgeScript;
    public static void assignPlayer(GameObject plyr)
    {
        player = plyr;
        playerShipDodgeScript = (shipRotation)plyr.GetComponent<shipRotation>();
    }
    public static Vector2 getPlayerPos()
    {
        return new Vector2(player.transform.position.x, player.transform.position.z);
    }
    public static bool getPlayerDodge()
    {
        return playerShipDodgeScript.isDodging();
    }

    public static void hitPlayer()
    {
        playerShipDodgeScript.isHit();
    }
}
