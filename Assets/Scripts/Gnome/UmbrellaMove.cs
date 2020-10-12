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
        [Tooltip("")]
        [SerializeField] private GameObject umbrellaObject;
        [SerializeField] private float abilityDuration;

        private WaitForSeconds wait;

        internal bool isUsingAbility = false;


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
        }


        private IEnumerator AbiltyCo()
        {
            isUsingAbility = true;
            umbrellaObject.SetActive(true);
            yield return wait;
            umbrellaObject.SetActive(false);
            isUsingAbility = false;
        }

        public void UseAbility()
        {
            // would anim into activating, for now its just gonna appear....
            if (!isUsingAbility)
            {
                StartCoroutine(AbiltyCo());
            }    
        }
    }
}