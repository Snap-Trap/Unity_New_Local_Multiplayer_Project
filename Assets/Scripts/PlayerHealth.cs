using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int Health = 2;
        public GameObject OtherPlayer;
        private Color startColor;
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Debug.Log("SpriteRenderer component found on the GameObject.");
                // Stores the first color of the sprite
                startColor = spriteRenderer.color;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on the GameObject.");
                // Just for me if it doesn't work :P
            }
        }

        public void HealthZero()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
                if (OtherPlayer != null) 
                // Checks if player one dies, player two also dies and vise versa
                {
                    Destroy(OtherPlayer); // Destroys the other player
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    ScoreManager.Result = 0;
                    ScoreManager.Score = 0;
                    // When the player dies, the scene is reloaded and the score is reset
                }


            }
        }

        public void HealthOne()
        {
            if (Health == 1)
            {
                GetComponent<Renderer>().material.color = Color.grey;
                // When the player takes damage, their color has a grey overlay
            }
        }

        public void GetDamage()
        {
            Health -= 1;
            HealthOne();
            HealthZero();
            // When the player touches an enemy, they take one damage
        }

        public void GetDamageSpike()
        {
            Health -= 2;
            HealthZero();
            // When the player touches a spike, they die instantly
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            //Different collisions (not triggers) give different results
            if (collision.gameObject.CompareTag("Enemy"))
            {
                GetDamage();
            }
            else if (collision.gameObject.CompareTag("Spike"))
            {
                GetDamageSpike();
            }
            else if (collision.gameObject.CompareTag("Coin"))
            {
                CoinHealthAdd();
            }
            
        }

        public void CoinHealthAdd()
        {
            Health += 1;
            HealthCapped(); // Healthcapped checks so the hp doesn't go above 2
        }

        public void HealthCapped()
        {
            if (Health >= 2)
            {
                Health = 2;

                spriteRenderer.color = startColor;
                // When the player gets a coin their health goes up, and the grey overlay is removed
            }
        }
    }
}
