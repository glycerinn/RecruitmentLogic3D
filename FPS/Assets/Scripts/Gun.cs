using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private float cooldown = 1;
    private float currentcooldown;
    AudioManager audioManager;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;
    public int bulletcount = 0;
    public int tilReload = 5;
    public bool isReloading = false;
    public Slider ammoslider;

    private void Awake()
    {
         audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammoslider.maxValue = 5;
        ammoslider.value = tilReload;
    }

    // Update is called once per frame
    void Update()
    {
        ammoslider.value = tilReload;
        if (isReloading) return;
        currentcooldown -= Time.deltaTime;
        if(currentcooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                shoot();
            }
        }
    }

    private void shoot()
    {
        fireGun();
        audioManager.playSFX(audioManager.attacksfx);
        currentcooldown = cooldown;
        bulletcount++;
        tilReload--;

        if(tilReload <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(1f);

        tilReload = 5;
        isReloading = false;
    }

    private void fireGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(destroyBullet(bullet, bulletPrefabLifeTime));
    }

    private IEnumerator destroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
