using UnityEngine;
using System.Collections;
public class bulletScript : MonoBehaviour {
    public float bulletSpeed;
    public bool aabb;
    public float radius;
    public float angle;
    public float timeAlive;
	// Use this for initialization
	void Start () {
        setAngle(angle);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
        timeAlive += Time.deltaTime;
        if (!aabb)
        {
            if (!playerManager.getPlayerDodge())
            {

                Vector2 myPos = new Vector2(transform.position.x, transform.position.z);
                Vector2 playerPos = playerManager.getPlayerPos();
                if(((myPos.x-playerPos.x)*(myPos.x-playerPos.x) + (myPos.y-playerPos.y)*(myPos.y-playerPos.y)) <= (radius*radius))
                {
                    playerManager.hitPlayer();
                }

            }
        }
        //bulletSpeed = (Mathf.Abs(3 - timeAlive) * Mathf.Abs(3 - timeAlive));
       
      
	}
    public void setAngle(float angle)
    {
        this.angle = angle;
        
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
