using System.Collections;
using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Entity PlayerSO;
    public Enemy enemy;
    public GameOverManager GameOverScreen;
    public float skillcool;
    public float ultcool;
    public int ultcount = 0, skillcount = 0;
    public bool meleeEnabled;
    AudioManager audioManager;
    public Slider playerSlider;
    public GameObject gun;
    public GameObject sword;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSlider.maxValue = PlayerSO.maxhealth;
        playerSlider.value = PlayerSO.health;
        PlayerSO.ResetHealth();
        skillcool = 0;
        ultcool = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider.value = PlayerSO.health;
        ultcool -= Time.deltaTime;
        skillcool -= Time.deltaTime;
        if (PlayerSO.health <= 0)
        {
            GameOver();
            Cursor.lockState =CursorLockMode.None;
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if(ultcool <= 0)
            {
                RunUlt();
                ultcount++;
            }
        }

          if(Input.GetKeyDown(KeyCode.E)){
            if(skillcool <= 0)
            {
                Runskill();
                skillcount++;
            }
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetUp();
        PlayerSO.ResetHealth();
        audioManager.playSFX(audioManager.deathsfx);
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("bullet");
        if(collision.gameObject.CompareTag("EnemyBullet")){
            PlayerSO.takeDamage(enemy.enemySO.damage);
        }
    }

    public IEnumerator Skill()
    {
        skillcool = 10;

        for(int i = 0; i < 5; i++)
        {
            PlayerSO.health += 10;
            yield return new WaitForSeconds(1f);
        }
    }

    public void Runskill()
    {
        StartCoroutine(Skill());
    }

     public void RunUlt()
    {
        StartCoroutine(Ult());
    }

    public IEnumerator Ult()
    {
        ultcool = 60;

        PlayerSO.health = 200;

        meleeEnabled = true;
        gun.SetActive(false);
        sword.SetActive(true);

        yield return new WaitForSeconds(20f);
        meleeEnabled = false;

        sword.SetActive(false);
        gun.SetActive(true);
    }
}
