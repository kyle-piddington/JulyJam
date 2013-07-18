using UnityEngine;
using System.Collections;

public class _patternConeFire : MonoBehaviour {

    public int bulletCount;
    public float fireSpreadAngle;
    public float refireTime;
    public int totalTime;
    public int resetTime;
    public float offsetAngle;
    public GameObject bullet;
    public float bulletSpeed;
    public bool startActive;
    public bool resets;
    private float refireTimer;
    private float totalTimer;
    private float resetTimer;
    // Use this for initialization
	void Start () {
        if (!startActive)
        {
            totalTimer = totalTime;
        }
	}
	
	// Update is called once per frame
	protected void Update () {
        if (totalTimer < totalTime || totalTime <= 0)
        {
            totalTimer += Time.deltaTime;
            refireTimer += Time.deltaTime;
            if (refireTimer > refireTime)
            {
                refireTimer = 0;
                if (bullet != null)
                {
                    for (int i = 0; i < bulletCount; i++)
                    {
                        GameObject b = Instantiate(bullet, transform.position,
                           Quaternion.identity) as GameObject;
                        

                        Bullet bScript = b.GetComponent(typeof(Bullet)) as Bullet;
                        if (bScript != null)
                        {
                            bScript.setSpeed(bulletSpeed);
                            if (bulletCount < 2)
                            {
                                bScript.setAngle(offsetAngle);
                            }
                            else
                            {
                                bScript.setAngle((offsetAngle - fireSpreadAngle/2 + fireSpreadAngle/(bulletCount-1)*i));
                            }
                            
                        }

                        else
                        {
                            Debug.Log("Could not find bullet script");
                        }
                    }
                }
                else
                {
                    Debug.Log("Bullet is not assigned!");
                }
            }
        }
        else if (resetTime > 0 && resets)
        {
            resetTimer += Time.deltaTime;
            Debug.Log("resetting:" + resetTime + "/" + resetTimer);
        }
        if (resetTimer > resetTime && resets)
        {
          
            resetTimer = 0;
            refireTimer = 0;
            totalTimer = 0;
        }
	    
	}
}
