using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class PlatformOneWay : MonoBehaviour
    {
        public bool IsUnder = false;

        void PlatformChecking()
        {
            if (IsUnder == true)
            {
                Debug.Log("Wall is solid, you are on top");
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
