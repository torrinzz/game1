using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float speed = 5; 
    float jumpSpeed = 10; 
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
