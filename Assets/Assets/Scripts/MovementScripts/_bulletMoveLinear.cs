using UnityEngine;
using System.Collections;

public class _bulletMoveLinear  : MonoBehaviour,Bullet {

    public float angle;
    public float speed;

    // Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(0, angle, 0));
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward  * speed * Time.deltaTime);
        if (!ScreenBounds.Contains(new Vector2(transform.position.x, transform.position.z))) 
        {
            Destroy(gameObject);
            
        }
    }
    public void setAngle(float angle)
    {
        this.angle = angle;
        transform.Rotate(new Vector3(0, this.angle - angle, 0));
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
