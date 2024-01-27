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

    [SerializeField] private Rigidbody2D rb; // Rigidbody for player

    // Keybinds for both players, change in inspector
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public bool isGrounded;

    void Start()
    {
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
        IsGroundedCheck();

        Vector2 direction = new Vector2(0, 0);
        if (Input.GetKey(left))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(right))
        {
            direction += Vector2.right;
        }


        _horizontal = direction.x;

        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
        
        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
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
}