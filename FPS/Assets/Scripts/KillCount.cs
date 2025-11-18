using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public TextMeshProUGUI MyCount;
    public int Kills;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Kills = 0;
        MyCount.text = Kills.ToString();
    }

    public void AddKills()
    {
        Kills++;
        MyCount.text = Kills.ToString();
    }

}
