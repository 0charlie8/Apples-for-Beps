using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 4f;
    public float jumpForce = 4f;
    private bool _isMoving;
    private bool isGrounded = true;

    private PlayerAnimation _an;
    private Vector3 _input;
    public SpriteRenderer sr;
    public LayerMask groundMask;
    private LegsScript ls;

    public GameObject button;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _an = GetComponentInChildren<PlayerAnimation>();
        ls = GetComponentInChildren<LegsScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                _an.Jump();
            }
        }
        isGrounded = ls.isGrounded;
        _an.isMoving = _isMoving;
        _an.isFlying = IsFlying();
        _an.grounded = isGrounded;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += _input * moveSpeed * Time.deltaTime;

        _isMoving = _input.x != 0 ? true : false;

        if (_isMoving)
        {
            sr.flipX = _input.x > 0 ? false : true;
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    bool IsFlying()
    {
        if (isGrounded == true)
            return false;
        else
            return true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform") && isGrounded)
        {
            this.transform.parent = collision.transform;
        }
        if (collision.CompareTag("TriggerBut"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                Trigger.Action();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }
    
}
