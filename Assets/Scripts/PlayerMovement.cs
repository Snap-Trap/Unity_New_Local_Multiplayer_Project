using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerNumber;
    private float _horizontal;
    private float _vertical;
    public float Speed = 8f;
    public float Jumppower = 10f;
    public LayerMask _groundLayer;


    private Rigidbody2D _rb;
    private bool isGrounded;

    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, _groundLayer);

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        float horizontalInput = Input.GetAxis("Horizontal_Player" + PlayerNumber);
        Vector2 movement = new Vector2(horizontalInput, 0);
        _rb.velocity = new Vector2(movement.x * Speed, _rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump_Player" + PlayerNumber))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, Jumppower);
        }
    }
}
