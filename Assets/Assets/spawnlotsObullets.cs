using UnityEngine;
using System.Collections;

public class spawnlotsObullets : MonoBehaviour {
    int currRotation;
    public int rotChangeAmount = 1;
    public int startRotation;
    public bulletScript bulletCopy;
    public int streamAmnt = 16;
    public float refireTimer = 0.15f;
    public float totalTime = 1;
    public float resetTime;
    public bool refires;
    public bool deletes;
    float resetTimer;
    float totalTimer;
    float timer;
	// Use this for initialization
	void Start () {
        currRotation = startRotation;
	}
	
	// Update is called once per frame
	void Update () {

        if (totalTimer <= totalTime)
        {
            timer += Time.deltaTime;
            totalTimer += Time.deltaTime;
            if (timer >= refireTimer)
            {
                timer = 0;
                for (int i = 0; i < streamAmnt; i++)
                {
                    bulletScript newBullet = Instantiate(bulletCopy, transform.position, Quaternion.identity) as bulletScript;

                    newBullet.setAngle(360 / streamAmnt * i + currRotation);
                }
                currRotation += rotChangeAmount;
            }
        }
        else if (refires && resetTimer < resetTime)
        {
            resetTimer += Time.deltaTime;
            //Debug.Log("Resetting:"+resetTimer+"/"+resetTime);
        }

        else if(resetTimer >= resetTime && refires)
        {
            Debug.Log("refiring");
            timer = refireTimer;
            totalTimer = 0;
            resetTimer = 0;
        }
        else if (deletes)
        {
            Destroy(gameObject);
        }
	}
}
