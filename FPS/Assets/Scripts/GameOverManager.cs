using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FinalScoreText;
    [SerializeField] TextMeshProUGUI CurrentScore;
    [SerializeField] TextMeshProUGUI FinalKillsText;
    [SerializeField] TextMeshProUGUI CurrentKills;
    public GameObject player;
    public GameObject gun;
 
    void Start()
    {

    }

    public void SetUp()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(true);
        FinalScoreText.text = CurrentScore.text;
        CurrentScore.gameObject.SetActive(false);
        FinalKillsText.text = CurrentKills.text;
        CurrentKills.gameObject.SetActive(false);

        player.GetComponent<PlayerBehavior>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<MouseMovement>().enabled = false;
        gun.GetComponent<Gun>().enabled = false;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        gameObject.SetActive(false);
        
        player.GetComponent<PlayerBehavior>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<MouseMovement>().enabled = true;
        gun.GetComponent<Gun>().enabled = true;
    }

    public void BacktoMenu()
    {
         Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
