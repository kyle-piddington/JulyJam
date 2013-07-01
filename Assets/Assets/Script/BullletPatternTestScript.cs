using UnityEngine;
using System.Collections;

public class BullletPatternTestScript : MonoBehaviour {
    public string fileName;
	// Use this for initialization
	void Start () {
        BulletPatternRegistry.readPatternsFromFile(fileName);    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
