using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Box"))
        {
            Debug.Log("Box entered the collision zone with the 'Box' tag. Destroying the door.");
            GameObject door = GameObject.FindWithTag("Door");
            if (door != null)
            {
                Destroy(door);
            }
            else
            {
                Debug.LogWarning("Door not found!");
            }
        }
    }
}