using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class DoorScript2 : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Box entered the collision zone with the 'Box' tag. Destroying the door.");
                GameObject door = GameObject.FindWithTag("Door2");
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
}
