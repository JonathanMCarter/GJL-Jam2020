using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BaseEnemyBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject sunTarget;
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float distantToTargetPlayer = 4f;
    [SerializeField] private float distantToAttackTarget = 1.4f;

    private Animator animator;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();

        //in case we're missing anythign then hunt for it here
        if (sunTarget == null)
        {
            try
            {
                sunTarget = GameObject.FindGameObjectWithTag("SunTarget"); 
            }
            catch (System.Exception)
            {
                Debug.Log("Theres no tagged SunTarget");
                throw;
            }
        }

        if (playerTarget == null)
        {
            try
            {
                playerTarget = GameObject.FindGameObjectWithTag("Player");
            }
            catch (System.Exception)
            {
                Debug.Log("Theres no tagged PlayerTarget");
                throw;
            }
        }  
        
        if (agent == null)
        {
            try
            {
                agent = gameObject.GetComponent<NavMeshAgent>();
                
            }
            catch (System.Exception)
            {
                Debug.Log("The enemy needs a nav mesh agent");
                throw;
            }
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
            checkCurrenttargetDistance(playerTarget);
        }
        else
        {
            agent.SetDestination(sunTarget.transform.position);
            checkCurrenttargetDistance(sunTarget);

        }        
    }

    private void checkCurrenttargetDistance(GameObject Target)
    {
        float targetDistance = Vector3.Distance (transform.position, Target.transform.position);

        if ( targetDistance < distantToAttackTarget)
        {
            animator.SetTrigger("Attack");
        }
    }

    // private void OnDrawGizmos() {
    //     //for testing show the area when the enemy will target the player
    //     Gizmos.DrawSphere(transform.position, distantToTargetPlayer);
    // }

    public GameObject getSunTarget()
    {
        return sunTarget;
    }
}
