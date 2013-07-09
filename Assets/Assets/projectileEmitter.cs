using UnityEngine;
using System.Collections;

public class projectileEmitter : MonoBehaviour {

    private KeyCode m1 = KeyCode.Mouse0;
    public Rigidbody projectile = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(m1))
        {
            Rigidbody clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 100);
            Destroy(clone.gameObject, 1);
        }
	
	}
}
