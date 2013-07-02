using UnityEngine;
using System.Collections;

public class shipRotation : MonoBehaviour {

    private Vector3 rotDir = new Vector3(0, 0, 0);
    private KeyCode rgt = KeyCode.D;
    private KeyCode lft = KeyCode.A;
    private float angle = 40;

	void Start () {
	
	}
	
	
	void Update () {

        float rotZ = transform.eulerAngles.z;

        if (rotZ > 180)
        {
            rotZ -= 360;
        }
        
        rotDir.Set(0, 0, -rotZ);

        if (Input.GetKey(rgt))
        {
           rotDir.z -= 1 * angle;
        }
        if (Input.GetKey(lft))
        {
            rotDir.z += 1 * angle;
        }

        print(rotDir.z);
        transform.Rotate(rotDir.normalized);
	
	}
}
