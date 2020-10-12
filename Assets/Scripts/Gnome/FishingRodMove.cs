using System.Collections;
using System.Net.Sockets;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public enum FishingRodAttack { Melee, Ranged };

    public class FishingRodMove : MonoBehaviour
    {
        [SerializeField] internal FishingRodAttack rodAttackType;
        [SerializeField] private GameObject fishingRodObject;

        [Header("Melee Attack")]
        [SerializeField] private float meleeAbilityDuration = .35f;

        [Header("Ranged Attack")]
        [SerializeField] private GameObject fishingRodProjectile;
        [SerializeField] private float rangedAbilityDuration = 1f;


        private WaitForSeconds meleeWait;

        private GnomeAttacks attacks;
        private GnomeMovement moves;
        private bool isCoR;
        private bool hasSwung;
        private bool shouldReturn;

        private void OnEnable()
        {
            attacks = GetComponent<GnomeAttacks>();
            moves = GetComponent<GnomeMovement>();
            fishingRodObject.SetActive(false);
        }


        private void Start()
        {
            meleeWait = new WaitForSeconds(meleeAbilityDuration);
        }


        private void Update()
        {
            if (attacks.GetActiveWeapon().Equals(GnomeWeapons.FishingRod) && !fishingRodObject.activeSelf)
            {
                fishingRodObject.SetActive(true);
            }
            else if (!attacks.GetActiveWeapon().Equals(GnomeWeapons.FishingRod) && fishingRodObject.activeSelf)
            {
                fishingRodObject.SetActive(false);
            }

            if (hasSwung)
            {
                fishingRodObject.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, fishingRodObject.transform.GetChild(0).transform.position);
                fishingRodObject.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, fishingRodProjectile.transform.position);
            }
        }


        private void FixedUpdate()
        {
            if (shouldReturn)
            {
                fishingRodProjectile.transform.position = Vector3.Lerp(fishingRodProjectile.transform.position, fishingRodObject.transform.GetChild(0).transform.position, .15f);
            }
        }


        public void UseAbility()
        {
            // would play an animation, for now its gonna move to a position and do something
            if (!isCoR)
            {
                if (rodAttackType.Equals(FishingRodAttack.Melee))
                {
                    // melee attack
                    StartCoroutine(SwingMeleeCo());
                }
                else
                {
                    // ranged attack
                    StartCoroutine(GoLongCo());
                }
            }
        }


        private IEnumerator SwingMeleeCo()
        {
            isCoR = true;
            attacks.anim.SetTrigger("MeleeRod");
            yield return meleeWait;
            isCoR = false;
        }


        private IEnumerator GoLongCo()
        {
            isCoR = true;
            attacks.anim.SetTrigger("RangedRod");
            yield return new WaitForSeconds(rangedAbilityDuration / 2);
            fishingRodProjectile.GetComponents<BoxCollider>()[1].enabled = true;
            yield return new WaitForSeconds(rangedAbilityDuration / 2);
            hasSwung = false;
            fishingRodObject.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
            fishingRodProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
            fishingRodProjectile.GetComponents<BoxCollider>()[1].enabled = false;
            fishingRodProjectile.GetComponent<Rigidbody>().useGravity = false;
            shouldReturn = true;
            yield return new WaitForSeconds(rangedAbilityDuration / 2);
            shouldReturn = false;
            fishingRodProjectile.SetActive(false);
            fishingRodProjectile.GetComponent<Rigidbody>().useGravity = true;
            moves.freezeGnome = false;
            isCoR = false;
        }


        public void SpawnProjectile()
        {
            fishingRodProjectile.transform.position = fishingRodObject.transform.GetChild(0).transform.position;
            fishingRodProjectile.transform.rotation = fishingRodObject.transform.GetChild(0).transform.rotation;
            fishingRodProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
            fishingRodProjectile.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
            fishingRodProjectile.SetActive(true);
            fishingRodObject.transform.GetChild(0).GetComponent<LineRenderer>().enabled = true;
            moves.freezeGnome = true;
            hasSwung = true;
        }
    }
}