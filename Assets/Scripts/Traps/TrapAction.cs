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

        internal TrapPlacementArea trapPlacementArea;
        [SerializeField] private GameObject soundPrefab;
        [SerializeField] private AudioClip _clip;

        private void OnEnable()
        {
            usesLeft = trap.numberOfUses;
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
                trapPlacementArea.hasTrap = false;
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

            if (hit.GetComponent<NavMeshAgent>() && hit.GetComponent<NavMeshAgent>().enabled)
            {
                hit.GetComponent<NavMeshAgent>().isStopped = true;
                hit.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            }

            hit.GetComponent<BaseEnemyBehaviour>().hitTrap = true;
            hit.GetComponentInChildren<Animator>().SetBool("IsMoving", false);
            tempParticles.transform.position = hit.transform.position;
            tempParticles.SetActive(true);

            if (hit.GetComponent<BaseEnemyBehaviour>().GetEnemyHealth() > 0)
            {
                ind.ShowDMGIndicator(new Vector3(hit.transform.position.x, hit.transform.position.y + 2.5f, hit.transform.position.z), trapDMG, Color.white);
                PlayClip(_clip, .1f);
            }

            yield return new WaitForSeconds(2f);
            hit.GetComponent<BaseEnemyBehaviour>().ReduceEnemyHealth(trapDMG);

            if (hit.GetComponent<NavMeshAgent>() && hit.GetComponent<NavMeshAgent>().enabled)
            {
                hit.GetComponent<NavMeshAgent>().isStopped = false;
            }

            hit.GetComponent<BaseEnemyBehaviour>().hitTrap = false;
            isCoR = false;
            usesLeft -= 1;
            StartCoroutine(TrapCooldown(1.5f));
        }


        private IEnumerator Fire()
        {
            isCoR = true;

            if (hit.GetComponent<BaseEnemyBehaviour>().GetEnemyHealth() > 0)
            {
                ind.ShowDMGIndicator(new Vector3(hit.transform.position.x, hit.transform.position.y + 2.5f, hit.transform.position.z), trapDMG, Color.white);
                PlayClip(_clip, .05f);
            }

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


        public void PlayClip(AudioClip _clip, float _volume = 1)
        {
            GameObject clip = Instantiate(soundPrefab);
            clip.GetComponent<AudioSource>().clip = _clip;
            clip.GetComponent<AudioSource>().volume = _volume;
            clip.GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
            clip.GetComponent<AudioSource>().Play();
            Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
        }
    }
}