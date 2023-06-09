using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float speed = 5; 
    float jumpSpeed = 10; 
    float runspeed = 10;
    float staspeed = 5;
    float stamina = 3;
  

    bool isGrounded;
    Rigidbody rb; 
    Vector3 direction; 
    
    void Start()
     {
         rb = GetComponent<Rigidbody>();
     }

    void Update()
     {
         float x = Input.GetAxis("Horizontal");
         float z = Input.GetAxis("Vertical");
         direction = transform.TransformDirection(x, 0, z);
    
         if(isGrounded)
        {
          if(Input.GetKeyDown(KeyCode.Space))
          {
              rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
          }

        }          
         if(Input.GetKey(KeyCode.LeftShift))
        {
            if(stamina > 0)
            {
                stamina -= Time.deltaTime;
                speed = runspeed;
            }
            else
            {
                speed = staspeed;
            }
        }
          else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            speed = staspeed;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
             speed = 6;
            }
        }
        if(stamina > 3f)
        {
            stamina = 3f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }
     }
    private void FixedUpdate()
     {
         rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
     }
     private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }



}
