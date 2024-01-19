using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;
    public float speed;
    public float jump;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;

    private bool running = false;

    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (Input.GetKeyDown(up) && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
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

        anim.SetBool("isJumping", !isGrounded());

        if (!isFacingRight && rb.velocity.x > 0)
        {
            Flip();
        }
        else if (isFacingRight && rb.velocity.x < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x = -1f;
        transform.localScale = localscale;
    }
    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        //GROUNDCHECK
        //Gizmos.DrawWireCube(transform.position - transform.up castDistance, boxSize);
    }
}