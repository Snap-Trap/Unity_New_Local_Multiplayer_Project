using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    // Variables for player movement
    private float _horizontal;
    public float _speed = 8f;
    public float _jumppower = 15f; // Jump power for jumping
    private bool _isfacingright = true; // For animation purposes with sprites

    [SerializeField] private Rigidbody2D rb; // Rigidbody for player

    // Keybinds for both players, change in inspector
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    private Animator anim;

    private bool running = false;
    public bool isGrounded;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log(Input.GetKeyDown(up));
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (Input.GetKey(up) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumppower);
        }
        else if (Input.GetKeyDown(up) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        else if (rb.velocity.x != 0)
        {
            running = true;
        }
        else
        {
            running = false;
        }

       anim.SetBool("isRunning", running);

       anim.SetBool("isJumping", !isGrounded);
        
        rb.velocity = new Vector2(_horizontal * _speed, rb.velocity.y);
        if (_horizontal > 0 && !_isfacingright)
        {
            Flip();
        }
        else if (_horizontal < 0 && _isfacingright)
        {
            Flip();
        }
    }

    void Flip()
    {
        if (_isfacingright && _horizontal < 0f || !_isfacingright && _horizontal > 0f)
        {
            _isfacingright = !_isfacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}