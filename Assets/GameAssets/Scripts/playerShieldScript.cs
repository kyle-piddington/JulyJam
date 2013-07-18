using UnityEngine;
using System.Collections;

public class playerShieldScript : MonoBehaviour {
    public bool active;
    public float targRad;
    private float shieldActivateTime = 0.15f;
   
    
    public float rad = 0;
    private float pSize = 0.1f;
    private float timer;

    // Use this for initialization
	void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {

        if (active && rad < targRad)
        {
            rad = Mathf.Lerp(0, targRad, (timer+=Time.deltaTime)/shieldActivateTime);
        }
        else if (!active && rad > 0)
        {
            rad = Mathf.Lerp(0, targRad, (timer -= Time.deltaTime) / shieldActivateTime);
        }
        transform.localScale = new Vector3(rad, rad, rad);
        collider.transform.localScale = new Vector3(rad, rad, rad);
	}

    void OnTriggerEnter(Collider other)
    {
        //check if the collision object has bulletProperties
        if (other.GetComponent<bulletProperties>() != null)
        {


            //destroy the bullet when it hits
            Destroy(other.transform.root.gameObject);

            //need to spawn and explosion when bullet hits. 
            //that would be baller
        }
    }
}
