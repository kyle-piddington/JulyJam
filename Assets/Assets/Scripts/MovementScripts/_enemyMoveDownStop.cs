using UnityEngine;
using System.Collections;

public class _enemyMoveDownStop : MonoBehaviour {

    public int targY;
    public int startY;
    public int startX;
    public int startSpeed;

	// Use this for initialization
	void Start () {
        transform.Translate(new Vector3(startX, 0, transform.position.z - startY));
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > targY)
        {
            transform.Translate(Vector3.forward * Mathf.Log(1 + (transform.position.z-targY)) * startSpeed*Time.deltaTime,Space.Self);
        }
	}
}
