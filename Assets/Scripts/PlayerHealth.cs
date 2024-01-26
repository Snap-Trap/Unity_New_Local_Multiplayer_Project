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

        public void HealthZero()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
                if (OtherPlayer != null)
                {
                    Destroy(OtherPlayer);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    ScoreManager.Result = 0;
                    ScoreManager.Score = 0;
                }


            }
        }

        public void HealthOne()
        {
            if (Health == 1)
            {
                GetComponent<Renderer>().material.color = Color.grey;
            }
        }

        public void GetDamage()
        {
            Health -= 1;
            HealthOne();
            HealthZero();
        }

        public void GetDamageSpike()
        {
            Health -= 2;
            HealthZero();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                GetDamage();
            }
            else if (collision.gameObject.CompareTag("Spike"))
            {
                GetDamageSpike();
            }
        }

        public void CoinHealthAdd()
        {
            Health += 1;
            HealthCapped();
        }

        public void HealthCapped()
        {
            if (Health > 2)
            {
                Health = 2;
            }
        }
    }
}
