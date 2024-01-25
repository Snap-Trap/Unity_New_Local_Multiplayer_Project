using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class PlatformCheck : MonoBehaviour
    {
        private PlatformOneWay platformOneWay;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                platformOneWay.IsUnder = true;
            }
        }
    }
}