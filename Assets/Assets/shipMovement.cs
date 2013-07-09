using System;
using UnityEngine;


public class shipMovement : MonoBehaviour
{
    private KeyCode frwd = KeyCode.W;
    private KeyCode bkwd = KeyCode.S;
    private KeyCode rgt = KeyCode.D;
    private KeyCode lft = KeyCode.A;
    private KeyCode space = KeyCode.Space;
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
            rotDir.z += 1;
            time = 0;
        }
   
        
        transform.Translate(transform.TransformDirection(movDir.normalized) * speed);
       
    }

  

  



}

