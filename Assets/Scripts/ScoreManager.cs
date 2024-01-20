using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public static int CoinValue = 10;
        public static int Score;
        public static int Result = 0;

        public void FixedUpdate()
        {
            ScoreText.text = ScoreText.ToString();
            ScoreText.text = "HighScore: " + Result;
        }

        public static void AddScore()
        {
            Score++;
            Result = Score * CoinValue;
        }
    }
}