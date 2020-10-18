using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DresslikeaGnome.OhGnomes
{
    public class BaseEnemyBehaviour : MonoBehaviour
    {
        // Jonathan added this
        [SerializeField] private int enemyHealth;

        [SerializeField] private GameObject sunTarget;
        [SerializeField] private GameObject playerTarget;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float distantToTargetPlayer = 4f;
        [SerializeField] private float distantToAttackTarget = 1.4f;

        private int defaultHealth;
        internal bool hitTrap;

        private Animator animator;
        private bool IsCoR;



        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnEnable()
        {
            IsCoR = false;

            if (agent)
            {
                agent.enabled = true;

                for (int i = 0; i < GetComponentsInChildren<BoxCollider>().Length; i++)
                {
                    GetComponentsInChildren<BoxCollider>()[i].enabled = true;
                }
            }
        }


        protected virtual void Awake()
        {
            animator = GetComponentInChildren<Animator>();

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

            defaultHealth = enemyHealth;
        }

        // Update is called once per frame
        protected virtual void Update()
        {

            //the enemy should go for the sun initially
            checkPlayerDistance();

            // jonathan added this
            if (enemyHealth <= 0)
            {
                if (!IsCoR)
                {
                    animator.SetTrigger("IsDead");

                    if (agent && agent.enabled)
                    {
                        agent.enabled = false;

                        for (int i = 0; i < GetComponentsInChildren<BoxCollider>().Length; i++)
                        {
                            GetComponentsInChildren<BoxCollider>()[i].enabled = false;
                        }
                    }

                    StartCoroutine(Despawn());
                }
            }

            if (agent.velocity.x > .15f && agent.velocity.z > .15f)
            {
                animator.SetBool("IsMoving", false);
            }
        }

        private void checkPlayerDistance()
        {
            //find out how far the player is from the enemy
            float playerDistance = Vector3.Distance(transform.position, playerTarget.transform.position);

            if (!hitTrap)
            {
                //If the player is close enough then target them
                if (playerDistance < distantToTargetPlayer)
                {
                    if (agent && agent.enabled)
                    {
                        agent.SetDestination(playerTarget.transform.position);
                    }

                    checkCurrenttargetDistance(playerTarget);
                }
                else
                {
                    if (agent && agent.enabled)
                    {
                        agent.SetDestination(sunTarget.transform.position);
                    }

                    checkCurrenttargetDistance(sunTarget);
                }
            }
        }

        private void checkCurrenttargetDistance(GameObject Target)
        {
            float targetDistance = Vector3.Distance(transform.position, Target.transform.position);

            if (targetDistance < distantToAttackTarget)
            {
                // jonathan (stops the NMA from pushing the gnome around xD)
                if (agent && agent.enabled)
                {
                    agent.isStopped = true;
                }

                animator.SetTrigger("Attack");
                animator.SetBool("IsMoving", false);

                if (Target.gameObject.CompareTag("Player") && enemyHealth > 0)
                {
                    transform.LookAt(playerTarget.transform);
                }
            }
            else
            {
                if (agent && agent.enabled)
                {
                    agent.isStopped = false;
                }
            
                animator.SetBool("IsMoving", true);
            }
        }

        // private void OnDrawGizmos() {
        //     //for testing show the area when the enemy will target the player
        //     Gizmos.DrawSphere(transform.position, distantToTargetPlayer);
        // }


        private IEnumerator Despawn()
        {
            IsCoR = true;
            yield return new WaitForSeconds(2.5f);
            gameObject.SetActive(false);
        }


        public GameObject getSunTarget()
        {
            return sunTarget;
        }

        // Jonathan added this
        public int GetEnemyHealth()
        {
            return enemyHealth;
        }

        // Jonathan added this
        public void ReduceEnemyHealth(int value)
        {
            enemyHealth -= value;
            animator.SetTrigger("IsHit");
        }

        // Jonathan added this
        public void ResetHealth()
        {
            enemyHealth = defaultHealth;
        }
    }
}