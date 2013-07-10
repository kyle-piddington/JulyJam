
using UnityEngine;
using System.Collections;

public class shipRotation : MonoBehaviour
{


    private KeyCode rgt = KeyCode.D;
    private KeyCode lft = KeyCode.A;
    private KeyCode shift = KeyCode.LeftShift;
    private float angleAdjustSpeed = 1;
    private float rollSpeed = 45;
    private float currAngle = 0;
    private float rollAngle = 0;
    private int rollDir = 1;

    private readonly float maxAngle = 35; //Readonly is the same as final

    void Start()
    {

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
            Debug.Log(rollAngle);
        }
        else if (rollAngle > 0)
        {

            transform.Rotate(new Vector3(0, 0, (rollAngle) * rollDir));
            rollAngle = 0;

        }
        if (Input.GetKey(rgt))
        {
            if (currAngle - angleAdjustSpeed > -maxAngle)
            {
                currAngle -= angleAdjustSpeed * 1;
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed));
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
                transform.Rotate(new Vector3(0, 0, +angleAdjustSpeed));
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
                transform.Rotate(new Vector3(0, 0, angleAdjustSpeed));
                currAngle += angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
                //Debug.Log("moving left");
            }
            else if (currAngle - angleAdjustSpeed > 0)
            {
                transform.Rotate(new Vector3(0, 0, -angleAdjustSpeed));
                currAngle -= angleAdjustSpeed;
                if (rollAngle == 0)
                {
                    rollDir = -1;
                }
                //Debug.Log("returning right");
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 0 - currAngle));
                currAngle = 0;
                if (rollAngle == 0)
                {
                    rollDir = 1;
                }
            }
        }
        if (Input.GetKey(shift) && rollAngle == 0)
        {
            rollAngle = +(360);

        }

        //Debug.Log(currAngle);

       

        //print(rotDir.z);
        //transform.Rotate(rotDir.normalized);

    }
}

