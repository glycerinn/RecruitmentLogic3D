using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class Sword : MonoBehaviour
{
    public float attackDist = 5f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage = 40;
    public PlayerBehavior player;
    bool attacking = false;
    bool ready = true;
    public Animator animator;
    public LayerMask attacklayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void attack()
    {
        if(player.meleeEnabled == true){
            if(ready || !attacking)
            {
                ready = false;
                attacking = true;

                Invoke(nameof(resetAttack), attackSpeed);
                Invoke(nameof(attackraycast), attackDelay);
                animator.SetTrigger("Slash");
                StartCoroutine(backtoIdle());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }
    }

    void resetAttack()
    {
        attacking = false;
        ready = true;
    }

    private IEnumerator backtoIdle()
    {
        yield return new WaitForSeconds(2f);

        animator.SetTrigger("BackToIdle");
    }

    void attackraycast()
    {
        if(Physics.Raycast(player.transform.position, player.transform.forward, out RaycastHit hit, attackDist, attacklayer))
        {
            if(hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.enemySO.takeDamage(40);
            }
        }
    }
}
