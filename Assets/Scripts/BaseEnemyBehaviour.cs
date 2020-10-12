using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject sunTarget;
    [SerializeField] private GameObject playerTarget;
    [SerializeField] private NavMeshAgent agent;

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
        agent.SetDestination(sunTarget.transform.position);
    }
}
