using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PatternInitializer : MonoBehaviour {
//Loads models and patterns in to bullets

    public   List<GameObject> bulletModels;
    public   string fileName;
    void Start()
    {
        BulletPatternRegistry.loadGameModels(bulletModels);
        BulletPatternRegistry.readPatternsFromFile(fileName);
    }
}
