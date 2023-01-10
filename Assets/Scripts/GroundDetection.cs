using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool isGrounded;
 


    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Platform(1)"))
        {
            isGrounded = true;


        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Platform(1)"))
        {
            isGrounded = false;


        }

    }
}
    
