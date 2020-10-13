using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class UmbrellaMove : MonoBehaviour
    {
        [Header("The Umbrealla")]
        [SerializeField] private GameObject umbrellaObject;
        [SerializeField] private float abilityDuration;
        [SerializeField] private float abilityCooldown;

        private WaitForSeconds wait;
        private GnomeStats gnome;

        internal bool isUsingAbility = false;
        internal bool canUseAbility = true;


        private void OnEnable()
        {
            umbrellaObject.SetActive(false);
        }


        private void OnDisable()
        {
            StopAllCoroutines();   
        }

        private void Start()
        {
            wait = new WaitForSeconds(abilityDuration);
            gnome = GetComponent<GnomeStats>();
        }


        private IEnumerator AbiltyCo()
        {
            isUsingAbility = true;
            umbrellaObject.SetActive(true);
            gnome.isInvun = true;
            yield return wait;
            gnome.isInvun = false;
            umbrellaObject.SetActive(false);
            isUsingAbility = false;
            StartCoroutine(CooldownCo());
        }

        public void UseAbility()
        {
            // would anim into activating, for now its just gonna appear....
            if (!isUsingAbility && canUseAbility)
            {
                StartCoroutine(AbiltyCo());
            }    
        }

        private IEnumerator CooldownCo()
        {
            canUseAbility = false;
            yield return new WaitForSeconds(abilityCooldown);
            canUseAbility = true;
        }
    }
}