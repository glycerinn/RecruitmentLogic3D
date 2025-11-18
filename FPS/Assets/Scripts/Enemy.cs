using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Entity enemySO;
    private Vector3 lastKnownPosition;
    public PlayerBehavior playerBehavior;
    private NavMeshAgent navAgent;
    public Vector3 respawnAreaSize = new Vector3(15, 0, 15);
    private Renderer[] renderers;
    private Collider[] colliders;

    private float cooldown = 5;
    private float currentcooldown;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;
    public ScoreManager scoreManager;
    public KillCount killCount;
    private bool hasScore = false;
    AudioManager audioManager;
    public Slider enemySlider;
    public GameObject enemySliders;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemySlider.maxValue = enemySO.maxhealth;
        enemySlider.value = enemySO.health;
        enemySO.ResetHealth();
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet")){
            enemySO.takeDamage(playerBehavior.PlayerSO.damage);
        }
        if(collision.gameObject.CompareTag("Sword")){
            enemySO.takeDamage(40);
        }
    }
    
    private void Update()
    {
        enemySlider.value = enemySO.health;
        if (enemySO.health <= 0 && !hasScore)
        {
            hasScore = true;
            StartCoroutine(Respawn());
            scoreManager.AddScore();
            killCount.AddKills();

        }
        if (animator.GetBool("Shoot"))
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 6f);
            }
        }
        currentcooldown -= Time.deltaTime;
        if(currentcooldown <= 0 && animator.GetBool("Shoot") == true)
        {
            lastKnownPosition = player.position;
            fireGun();
            currentcooldown = cooldown;
        }
    }

    public IEnumerator Respawn()
    {
        audioManager.playSFX(audioManager.deathsfx);
        animator.SetTrigger("Die");
        navAgent.enabled = false;

        yield return new WaitForSeconds(3f);

        enemySliders.SetActive(false);

        SetVisibility(false);

        Vector3 randomlocation = getrandomlocation();
        transform.position = randomlocation;

        yield return new WaitForSeconds(2f);

        animator.enabled = true;

        enemySO.ResetHealth();
        animator.ResetTrigger("Die");
        animator.Play("Idle");

        navAgent.enabled = true;
        enemySliders.SetActive(true);


        SetVisibility(true);

        hasScore = false;
    }

    private Vector3 getrandomlocation()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-respawnAreaSize.x / 2, respawnAreaSize.x / 2),
            0,
            Random.Range(-respawnAreaSize.z / 2, respawnAreaSize.z / 2)
        );

        return transform.parent ? transform.parent.position + randomOffset : transform.position + randomOffset;
    }

    private void SetVisibility(bool state)
    {
        foreach (Renderer r in renderers) r.enabled = state;
        foreach (Collider c in colliders) c.enabled = state;
    }   

    private void fireGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Vector3 direction = (lastKnownPosition - bulletSpawn.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(direction * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(destroyBullet(bullet, bulletPrefabLifeTime));
    }

    private IEnumerator destroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
