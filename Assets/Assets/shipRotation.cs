
using UnityEngine;
using System.Collections;

public class shipRotation : MonoBehaviour
{

    private Vector3 rotDir = new Vector3(0, 0, 0);
    private KeyCode rgt = KeyCode.RightArrow;
    private KeyCode lft = KeyCode.LeftArrow;
    private KeyCode Ckey = KeyCode.C;
    private float angleAdjustSpeed = 5;
    private float rollSpeed = 25;
    private float currAngle = 0;
    private float rollAngle = 0;
    private int rollDir = 1;
    private bool dodging;
    private readonly float maxAngle = 35; //Readonly is the same as final

    void Start()
    {
        playerManager.assignPlayer(this.gameObject);
    }


    void Update()
    {

        float rotZ = transform.eulerAngles.z;

        if (rotZ > 180)
        {
            rotZ -= 360;
        }

        //rotDir.Set(0, 0, -rotZ);
        if (rollAngle - rollSpeed >= 0)
        {
            transform.Rotate(new Vector3(0, 0, rollSpeed * rollDir));
            rollAngle -= rollSpeed;
            
        }
        else if (rollAngle > 0)
        {

            transform.Rotate(new Vector3(0, 0, (rollAngle) * rollDir));
            rollAngle = 0;
            dodging = false;

        }
        if (Input.GetKey(rgt))
        {
            if (currAngle - angleAdjustSpeed > -maxAngle)
            {
                currAngle -= angleAdjustSpeed * 1;
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed),Space.World);
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
                transform.Rotate(new Vector3(0, 0, +angleAdjustSpeed),Space.World);
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
                transform.Rotate(new Vector3(0, 0, angleAdjustSpeed),Space.World);
                currAngle += angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
                //Debug.Log("moving left");
            }
            else if (currAngle - angleAdjustSpeed > 0)
            {
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed),Space.World);
                currAngle -= angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = -1;
                }
                //Debug.Log("returning right");
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 0 - currAngle),Space.World);
                currAngle = 0;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
            }
        }
        if (Input.GetKey(Ckey) && rollAngle == 0)
        {
            rollAngle = (360);
            dodging = true;
        }
    }

        //Debug.Log(currAngle);
    public bool isDodging()
    {
        return dodging;
    }
    public void isHit()
    {
        Time.timeScale = 0;
    }
       

      

    
}

