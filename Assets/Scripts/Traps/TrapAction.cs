using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class TrapAction : MonoBehaviour
    {
        [SerializeField] private TrapTypes trapType;
        [SerializeField] private TrapStats trap;

        private GameObject tempParticles;
        private GameObject hit;
        private int usesLeft;
        private int trapDMG;
        private bool isCoR;
        private bool isTrapReady;
        private DamageIndicator ind;


        private void OnEnable()
        {
            isTrapReady = true;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Start()
        {
            ind = FindObjectOfType<DamageIndicator>();
            usesLeft = trap.numberOfUses;
            trapDMG = trap.trapDMG;

            if (trap.extra.Length > 0)
            {
                if (trap.extra[0])
                {
                    tempParticles = Instantiate(trap.extra[0]);
                    tempParticles.SetActive(false);
                }
            }
        }


        private void Update()
        {
            if (usesLeft.Equals(0))
            {
                gameObject.SetActive(false);
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(other.gameObject.name);

                if (other.gameObject.GetComponent<BaseEnemyBehaviour>() && !isCoR && isTrapReady)
                {
                    hit = other.gameObject;

                    switch (trapType)
                    {
                        case TrapTypes.None:
                            break;
                        case TrapTypes.Cable:
                            StartCoroutine(Electo());
                            break;
                        case TrapTypes.BBQ:
                            StartCoroutine(Fire());
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private IEnumerator Electo()
        {
            isCoR = true;
            hit.GetComponent<NavMeshAgent>().isStopped = true;
            hit.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            hit.GetComponent<BaseEnemyBehaviour>().hitTrap = true;
            ind.ShowDMGIndicator(new Vector3(hit.transform.position.x, hit.transform.position.y + 1.5f, hit.transform.position.z), trapDMG, Color.white);
            tempParticles.transform.position = hit.transform.position;
            tempParticles.SetActive(true);
            yield return new WaitForSeconds(2f);
            hit.GetComponent<BaseEnemyBehaviour>().ReduceEnemyHealth(trapDMG);
            hit.GetComponent<NavMeshAgent>().isStopped = false;
            hit.GetComponent<BaseEnemyBehaviour>().hitTrap = false;
            isCoR = false;
            usesLeft -= 1;
            StartCoroutine(TrapCooldown(1.5f));
        }


        private IEnumerator Fire()
        {
            isCoR = true;
            ind.ShowDMGIndicator(new Vector3(hit.transform.position.x, hit.transform.position.y + 1.5f, hit.transform.position.z), trapDMG, Color.white);
            yield return new WaitForSeconds(.25f);
            hit.GetComponent<BaseEnemyBehaviour>().ReduceEnemyHealth(trapDMG);
            isCoR = false;
            usesLeft -= 1;
            StartCoroutine(TrapCooldown(.25f));
        }


        private IEnumerator TrapCooldown(float delay)
        {
            isTrapReady = false;
            yield return new WaitForSeconds(delay);
            isTrapReady = true;
        }
    }
}