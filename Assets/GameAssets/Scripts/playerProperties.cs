using UnityEngine;
using System.Collections;

public class playerProperties : MonoBehaviour {
	
	public int health;
	public int shield;
	public int lives;
	
	//temp variable to store bullet damage
	private int damageTaken;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	void OnTriggerEnter(Collider other)
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
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void onHit(int damage)
	{
		//does damage to shield and if it goes past shield, does damage to health
		//yes, i know its coded very strange and the reason for that
		//is to provide a seamless transition between shield damage and health damage.
		//i.e. if you have 3 shield and 100 health, and bullet deals 5,
		//you'll have 0 shield and 98 health.
		
		//don't change it unless it comes down to performance.
		
		shield-=damage;

		if(shield<0)
		{
			health+=shield;
			shield = 0;
		}
		
		
		//destroys player if he dies.
		// we need to make player a prefab so that we can have multiple lives
		if(health<=0)
		{
			
			/*if(lives>0)
			{
				CREATE NEW PLAYER PREFAB
			}
			
			else
			{
				GAME OVER MOTHER FUCKER
			}*/
		}
		
		
	}
	
}
