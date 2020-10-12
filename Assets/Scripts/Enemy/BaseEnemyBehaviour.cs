using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[SerializeField]
public class BaseEnemyBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject sunTarget;
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float distantToTargetPlayer = 4f;
    [SerializeField] private float distantToAttackTarget = 1.4f;

    private Animator animator;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

        //in case we're missing anythign then hunt for it here
        if (sunTarget == null)
        {
            sunTarget = GameObject.FindGameObjectWithTag("SunTarget");
        }

        if (playerTarget == null)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player");
        }  
        

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //the enemy should go for the sun initially
        checkPlayerDistance();
    }

    private void checkPlayerDistance()
    {
        //find out how far the player is from the enemy
        float playerDistance = Vector3.Distance (transform.position, playerTarget.transform.position);

        //If the player is close enough then target them
        if ( playerDistance < distantToTargetPlayer)
        {
            agent.SetDestination(playerTarget.transform.position);
            checkCurrentTargetDistance(playerTarget);
        }
        else
        {
            agent.SetDestination(sunTarget.transform.position);
            checkCurrentTargetDistance(sunTarget);

        }        
    }

    private void checkCurrentTargetDistance(GameObject Target)
    {
        float TargetDistance = Vector3.Distance (transform.position, Target.transform.position);

        if ( TargetDistance < distantToAttackTarget)
        {
            animator.SetTrigger("Attack");
        }
    }

    // private void OnDrawGizmos() {
    //     //for testing show the area when the enemy will target the player
    //     Gizmos.DrawSphere(transform.position, distantToTargetPlayer);
    // }
}
