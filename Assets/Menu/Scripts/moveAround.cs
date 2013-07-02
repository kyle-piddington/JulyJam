using UnityEngine;
using System.Collections;

public class moveAround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void Update () {
		
		transform.RotateAround (new Vector3(113,48,1213),Vector3.left,20*Time.deltaTime);
	}
}
