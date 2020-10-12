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

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
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
    void Update()
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
        }
        else
        {
            agent.SetDestination(sunTarget.transform.position);
        }
        
    }

    private void OnDrawGizmos() {
        //for testing show the area when the enemy will target the player
        Gizmos.DrawSphere(transform.position, distantToTargetPlayer);
    }
}
