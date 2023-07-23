using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LegsScript : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
