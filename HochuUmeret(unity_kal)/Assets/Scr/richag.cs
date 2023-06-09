using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class richag : MonoBehaviour
{
    [SerializeField] Animator door;
    [SerializeField] Animator Richag;
    private void OnTriggerEnter(Collider other)
 {
    if(other.CompareTag("Player")) 
    {
        print("антон");
        if(Input.GetKey(KeyCode.E))
        {
           door.SetTrigger("open");
           Richag.SetTrigger("switch");
        }
    }
 }
}
