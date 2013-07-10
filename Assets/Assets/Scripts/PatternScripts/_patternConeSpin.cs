using UnityEngine;
using System.Collections;

public class _patternConeSpin : _patternConeFire {

    public float angleMomentum;
	// Use this for initialization

    void Update()
    {
        base.Update();
        base.offsetAngle += angleMomentum * Time.deltaTime;
    }
}
