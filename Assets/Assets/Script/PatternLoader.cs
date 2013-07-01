using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PatternLoader : MonoBehaviour {

    public List<GameObject> modelList;
    public string patternFileName;
	// Use this for initialization
	void Start () {
        BulletPatternRegistry.loadGameModels(modelList);
        BulletPatternRegistry.readPatternsFromFile(@"Assets/"+patternFileName);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
