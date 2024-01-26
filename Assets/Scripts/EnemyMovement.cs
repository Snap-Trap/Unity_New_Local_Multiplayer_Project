using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float EnemySpeed = 4f;
    private bool isFacingRight = true;

    void FixedUpdate()
    {
        if (isFacingRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * EnemySpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallTrigger"))
        {
            EnemySpeed = EnemySpeed * -1;
        }
    }
}
