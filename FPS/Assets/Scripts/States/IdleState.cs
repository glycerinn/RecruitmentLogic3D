using UnityEngine;
using UnityEngine.AI;

public class IdleStates : StateMachineBehaviour
{

    NavMeshAgent agent;

    public float idleTime = 0f;
    Transform player;
    public float detectionRadius = 40f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent.speed = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float distancefrom = Vector3.Distance(player.position, animator.transform.position);
       if(distancefrom < detectionRadius)
        {
            animator.SetBool("IsWalking", true);
        }
    }
}
