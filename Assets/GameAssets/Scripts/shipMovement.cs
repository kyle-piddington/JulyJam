using System;
using UnityEngine;


public class shipMovement : MonoBehaviour
{
    private KeyCode frwd = KeyCode.W;
    private KeyCode bkwd = KeyCode.S;
    private KeyCode rgt = KeyCode.D;
    private KeyCode lft = KeyCode.A;
    private KeyCode shift = KeyCode.LeftShift;
    private Vector3 movDir = new Vector3(0,0,0);

   
    private float angleAdjustSpeed = 1;
    private float rollSpeed = 25;
    private float currAngle = 0;
    private float rollAngle = 0;
    private int rollDir = 1;
    private float speed = 40f;

    private readonly float maxAngle = 35;
    void Start() { }
    
        
    void Update()
    { 
        movDir.Set(0, 0, 0);
    
        if (Input.GetKey(frwd)) {
            movDir.z += 1;
            
        }
        if (Input.GetKey(bkwd)) {
            movDir.z -= 1;
            
        }
        if (Input.GetKey(rgt)) {
            movDir.x += 1;
        
        }
        if (Input.GetKey(lft)) {
            movDir.x -= 1;
        }
        if (rollAngle - rollSpeed >= 0)
        {
            transform.Rotate(new Vector3(0, 0, rollSpeed * rollDir),Space.Self);
            rollAngle -= rollSpeed;
            //Debug.Log(rollAngle);
        }
        else if (rollAngle > 0)
        {

            transform.Rotate(new Vector3(0, 0, (rollAngle) * rollDir),Space.Self);
            rollAngle = 0;

        }
        if (Input.GetKey(rgt))
        {
            if (currAngle - angleAdjustSpeed > -maxAngle)
            {
                currAngle -= angleAdjustSpeed * 1;
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed),Space.Self);
            }
            if (rollAngle == 0)
            {
                rollDir = -1;
            }
        }
        else if (Input.GetKey(lft))
        {
            if (currAngle + angleAdjustSpeed < maxAngle)
            {
                currAngle += angleAdjustSpeed * 1;
                transform.Rotate(new Vector3(0, 0, +angleAdjustSpeed),Space.Self);
            }
            if (rollAngle == 0)
            {
                rollDir = 1;
            }
        }
        else if (rollAngle == 0)
        {
            if (currAngle + angleAdjustSpeed < 0)
            {
                transform.Rotate(new Vector3(0, 0, angleAdjustSpeed),Space.Self);
                currAngle += angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
                //Debug.Log("moving left");
            }
            else if (currAngle - angleAdjustSpeed > 0)
            {
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed),Space.Self);
                currAngle -= angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = -1;
                }
                //Debug.Log("returning right");
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 0 - currAngle),Space.Self);
                currAngle = 0;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
            }
        }
        if (Input.GetKey(shift) && rollAngle == 0)
        {
			if(gameObject.GetComponent<playerProperties>().dodgeMeter>0 && gameObject.GetComponent<playerProperties>().allowDodge)
			{
	            dodge ();
				gameObject.GetComponent<playerProperties>().dodgeMeter-=0.25f;
			}
        }
		
		
		if(!Input.GetKey (shift) && rollAngle == 0 && !gameObject.GetComponent<playerProperties>().dead)
		{
			gameObject.GetComponent<playerProperties>().allowCollisions = true;
		}
		
		if(gameObject.GetComponent<playerProperties>().dead)
		{
			dodge ();
		}
		
        transform.Translate((movDir.normalized) * speed*Time.deltaTime,Space.World);
   
    }

    void dodge()
	{
		if(rollAngle == 0) rollAngle = +(360);
		gameObject.GetComponent<playerProperties>().allowCollisions = false;
	}
  

  



}

