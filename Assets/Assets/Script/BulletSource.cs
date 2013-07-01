using UnityEngine;
using System.Collections;

public class BulletSource : MonoBehaviour {

    public string patternName;
    private BulletPattern pattern;
    // Use this for initialization
	void Start () {
        pattern = BulletPatternRegistry.getPattern(patternName); 
	}
	// Update is called once per frame
	void Update () {
	    pattern.Update();
	}
}
