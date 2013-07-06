using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SimpleBullet : BulletPattern {
    //Desc: A simple Bullet that travels in a straight line along it's angle
    //Params: float value for speed.
	// Use this for initialization

    public float speed;
    public SimpleBullet(List<BulletCommand> commandList, List<float> addlParams) : base(commandList,addlParams)
    {
        if (addlParams.Count > 0)
        {
            speed = addlParams[0];
        }
    }
    public SimpleBullet(BulletPattern copy)
        : base(copy)
    {
        if (addlParams.Count > 0)
        {
            Debug.Log(addlParams[0]);
            speed = addlParams[0];
        }
        else
        {
            speed = 0.1f;
        }
    }
	
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
       
	}
    protected override void move()
    {
        move(new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * speed, Mathf.Sin(Mathf.Deg2Rad * angle) * speed));
    }
}
