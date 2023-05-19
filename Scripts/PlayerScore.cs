using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI CurrentScoreText;
    public TextMeshProUGUI HighScoreText;

    private int currentScore;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = highScore.ToString();
    }

    public void IncreaseScore()
    {
        currentScore++;
        CurrentScoreText.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            HighScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
