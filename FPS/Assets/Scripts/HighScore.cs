using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public int Highscores;
    public TextMeshProUGUI MyHigh;

    void Start()
    {
        Highscores = PlayerPrefs.GetInt("HighScore", 0);
        MyHigh.text = "Best Score: " + Highscores.ToString();
    }

    public void LoadMenu()
    {
        gameObject.SetActive(false);
    }

     public void SetUp()
    {
        gameObject.SetActive(true);
    }
}
