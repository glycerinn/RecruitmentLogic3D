using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chaseSpeed = 3.5f;

    public float stopChase = 45;
    public float attackdistance = 30f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent = animator.GetComponent<NavMeshAgent>();

       agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distancefrom = Vector3.Distance(player.position, animator.transform.position);
        if (distancefrom > stopChase)
        {
            animator.SetBool("IsWalking", false);
            agent.speed = 0;
        }

        if (distancefrom < attackdistance)
        {
            animator.SetBool("Shoot", true);
            agent.speed = 0;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
