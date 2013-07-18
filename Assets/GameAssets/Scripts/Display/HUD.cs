using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	
	public float healthDisplay;
	public float dodgeDisplay;
	
	public Vector2 healthPos;
	public Vector2 healthSize;
	
	public Vector2 dodgePos;
	public Vector2 dodgeSize;
	
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	void Start()
	{
		
		CameraFade.StartAlphaFade (Color.white,true,1,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthDisplay = GameObject.Find("playerShip").GetComponent<playerProperties>().health;
		dodgeDisplay = GameObject.Find("playerShip").GetComponent<playerProperties>().dodgeMeter;
	}
	
	void OnGUI()
	{
		GUI.BeginGroup (new Rect (healthPos.x, healthPos.y, healthSize.x, healthSize.y));
	        GUI.Box (new Rect (0,0, healthSize.x, healthSize.y),progressBarEmpty);
	        // draw the filled-in part:
	        GUI.BeginGroup (new Rect (0, 0, healthSize.x * healthDisplay, healthSize.y));
				GUI.Box (new Rect (0,0, healthSize.x, healthSize.y),progressBarFull);
	        GUI.EndGroup ();
   		GUI.EndGroup ();
		
		GUI.BeginGroup (new Rect (dodgePos.x, dodgePos.y, dodgeSize.x, dodgeSize.y));
	        GUI.Box (new Rect (0,0, dodgeSize.x, dodgeSize.y),progressBarEmpty);
	        // draw the filled-in part:
	        GUI.BeginGroup (new Rect (0, 0, dodgeSize.x * dodgeDisplay, dodgeSize.y));
				GUI.Box (new Rect (0,0, dodgeSize.x, dodgeSize.y),progressBarFull);
	        GUI.EndGroup ();
   		GUI.EndGroup ();
	}
	
	
}
