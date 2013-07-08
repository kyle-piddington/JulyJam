using System;
using UnityEngine;


public class shipMovement : MonoBehaviour
{
    private KeyCode frwd = KeyCode.UpArrow;
    private KeyCode bkwd = KeyCode.DownArrow;
    private KeyCode rgt = KeyCode.RightArrow;
    private KeyCode lft = KeyCode.LeftArrow;
    private KeyCode space = KeyCode.Space;
    private KeyCode shift = KeyCode.LeftShift;
    private Vector3 movDir = new Vector3(0,0,0);
    private Vector3 rotDir = new Vector3(0,0,0);
    private float speed = 0.4f;


    
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
        if(Input.GetKey(shift))
        {
            speed = 0.15f;
        
        }
        else
        {
            speed = 0.4f;
        }
        transform.Translate(transform.TransformDirection(movDir.normalized) * speed,Space.World);
       
    }

  

  



}

