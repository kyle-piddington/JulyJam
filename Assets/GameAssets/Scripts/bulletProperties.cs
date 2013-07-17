using UnityEngine;
using System.Collections;

public class bulletProperties : MonoBehaviour {
	
	public float damage;
	public float lifespan;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifespan-=Time.deltaTime;
		
		if(lifespan<0)
		{
			Destroy (gameObject);
		}
	}
}
