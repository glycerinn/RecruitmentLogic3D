using UnityEngine;
using TMPro;

public class DescManager : MonoBehaviour
{
    public TextMeshProUGUI DescText;
    public GameObject player;
    public GameObject gun;
    public int bullets;
    public int ults;
    public int skills;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DescText.text = "Bullets: " + bullets.ToString() + 
                        "\nUlts: " + ults.ToString() +
                        "\nSkills: " + skills.ToString();
        
    }

    void Update()
    {
        bullets = gun.GetComponent<Gun>().bulletcount;
        ults = player.GetComponent<PlayerBehavior>().ultcount;
        skills = player.GetComponent<PlayerBehavior>().skillcount;
        DescText.text = "Bullets: " + bullets.ToString() + 
                        "\nUlts: " + ults.ToString() +
                        "\nSkills: " + skills.ToString();
    }
}
