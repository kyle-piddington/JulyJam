using UnityEngine;
using System.Collections;

public class bulletProperties : MonoBehaviour {
	
	public int damage;
	public float lifespan;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(lifespan-Time.deltaTime<0)
		{
			Destroy (gameObject);
		}
	}
}
