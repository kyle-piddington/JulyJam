using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
public class BulletSource : MonoBehaviour {

    public string patternName;
    private BulletPattern pattern;
    // Use this for initialization
	void Start () {
        
	}
    void initializePattern()
    {
        pattern = new SimpleBullet((BulletPatternRegistry.getPattern(patternName)));
        pattern.Start();
    }
	// Update is called once per frame
	void Update () {
        if (pattern == null)
        {
            initializePattern();
        }
        if (!pattern.getActive())
        {
            pattern.setActive(true);
        }
	    pattern.Update();
	}
}
