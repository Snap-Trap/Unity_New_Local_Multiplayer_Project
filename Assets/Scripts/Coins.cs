using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Coins : MonoBehaviour
    {
        public ScoreManager ScoreManager;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))//if (other.CompareTag("Player"))
            {
                Debug.Log("Coin collected");
                ScoreManager.AddScore();
                Debug.Log("Score: " + ScoreManager.ScoreText);
                Destroy(gameObject);
            }
        }
    }
}