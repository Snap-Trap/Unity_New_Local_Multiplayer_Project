using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    // Variables for player movement
    private float _horizontal;
    public float speed = 8f;
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

    void Update()
    {

        if (Input.GetKeyDown(up) && isGrounded)
        {
            rb.AddForce(Vector2.up * _jumppower, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(Input.GetKeyDown(up));

        IsGroundedCheck();

        Vector2 direction = new Vector2(0, 0);
        if (Input.GetKey(left))
        {
            direction += Vector2.left;
            running = true;
        }

        if (Input.GetKey(right))
        {
            direction += Vector2.right;
            running = true;
        }


        _horizontal = direction.x;

        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);

        anim.SetBool("isRunning", running);

        anim.SetBool("isJumping", !isGrounded);
        
        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
        if (_horizontal > 0 && !_isfacingright)
        {
            Flip();
        }
        else if (_horizontal < 0 && _isfacingright)
        {
            Flip();
        }
    }

    private void IsGroundedCheck()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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

}