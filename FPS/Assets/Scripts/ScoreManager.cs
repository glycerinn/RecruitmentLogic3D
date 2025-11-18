using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI MyScore;
    public int Score;
    public int HighScoreScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreScore = PlayerPrefs.GetInt("HighScore", 0);
        Score = 0;
        MyScore.text = Score.ToString();
    }

    public void AddScore()
    {
        Score += 100;
        MyScore.text = Score.ToString();
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }

   
}