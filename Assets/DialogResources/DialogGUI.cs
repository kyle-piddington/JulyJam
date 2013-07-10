using UnityEngine;
using System.Collections;

public class DialogGUI : MonoBehaviour {

	public string dialog;
	public string character;
	public Texture portrait;

	void OnGUI () 
	{
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.MiddleCenter;		

		GUI.Box (new Rect (0,Screen.height-Screen.height/4,Screen.width,Screen.height/4), "");
		GUI.Label(new Rect (Screen.width/5,Screen.height-Screen.height/4,Screen.width*4/5,Screen.height/4), dialog, centeredStyle);


		centeredStyle.alignment = TextAnchor.LowerCenter;
		GUI.Box (new Rect(75,Screen.height-Screen.height/4+8, 90,100), portrait);
		GUI.Label(new Rect(75,Screen.height-Screen.height/4+10, 90,100), character, centeredStyle);
	}
}
