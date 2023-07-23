using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator an;
    
    public bool isMoving { private get; set; }

    public bool isFlying { private get; set; }

    public bool grounded { private get; set; }

    void Start()
    {
        an = GetComponent<Animator>();
    }

    
    void Update()
    {
        an.SetBool("isMoving", isMoving);
        an.SetBool("isFlying", isFlying);
        an.SetBool("isGrounded", grounded);
    }

    public void Jump()
    {
        an.SetTrigger("Jump");
    }
}
