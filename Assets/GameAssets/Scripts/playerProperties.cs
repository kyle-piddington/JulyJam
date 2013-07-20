using UnityEngine;
using System.Collections;

public class playerProperties : MonoBehaviour {
	
	public float health;
	public int lives;
	public bool dead;
	
	public Vector3 startPos = new Vector3(0.3450498f,-1f,-16.43601f);
	
	//variable to determine
	public float dodgeMeter;
	
	//varaible to determine whether you can take damage or not
	public bool allowCollisions;
	
	//prevents dodging while dead;
	public bool allowDodge;
	
	//variable to make sure you're dead for a certain amount of time
	private float standbyTime;
	
	//temp variable to store bullet damage
	private float damageTaken;
	
	private Renderer renderer;
	
	// Use this for initialization
	void Start () 
	{
		allowCollisions = true;
		allowDodge = true;
		standbyTime = 0;
		renderer = GetComponentInChildren<Renderer>(); //finds the appropriate renderer in the playerShip gameObject group
		dead = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(allowCollisions)
		{
			//check if the collision object has bulletProperties
			if(other.GetComponent<bulletProperties>()!=null)
			{
				//ask bullet how much damage it deals and then deal damage
				damageTaken = other.GetComponent<bulletProperties>().damage;
				onHit(damageTaken);
				
				//destroy the bullet when it hits
				Destroy (other.transform.root.gameObject);
				
				//need to spawn and explosion when bullet hits. 
				//that would be baller
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health<=0) dead = true;
		
		if(dead)
		{
			renderer.enabled = false;
			allowDodge = false;
			
			if(lives>0)
			{
				Debug.Log ("dead");

				standbyTime+=Time.deltaTime;
				
				//if(health<1) health+=0.003f;
				
				if(standbyTime>2.9 && standbyTime<3.1)
				{
					transform.position = startPos;
					health = 1;
				}
				
				if(standbyTime>3) renderer.enabled = true;
				
				if(standbyTime>5)
				{
					dead = false;
					allowDodge = true;
					standbyTime = 0;
					lives--;
					renderer.enabled = true;
				}
			}
			
			else
			{
				Debug.Log("GAME OVER MOTHER FUCKER");
			}
		}
	}
	
	void onHit(float damage)
	{
		health-=damage;
	}	
}
