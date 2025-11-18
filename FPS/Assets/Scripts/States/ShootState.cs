using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class ShootState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float stopattackdistance = 30f;

     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent = animator.GetComponent<NavMeshAgent>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookatPlayer();
        float distancefrom = Vector3.Distance(player.position, animator.transform.position);

        if (distancefrom > stopattackdistance)
        {
            animator.SetBool("Shoot", false);
        }
    }

    private void LookatPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yrotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yrotation, 0);
    }
}
