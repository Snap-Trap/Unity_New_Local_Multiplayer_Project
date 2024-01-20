using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class HighScoreDisplay : MonoBehaviour
    {
        private static TextMeshProUGUI _scoreText;
        public static ScoreManager ScoreManager;

        public void GetText()
        {
            _scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void Update()
        {
            _scoreText.text = "HighScore: " + ScoreManager.Result;
        }
    }
}