using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class GnomeStats : MonoBehaviour
    {
        [SerializeField] private float invunTime = .5f;
        private WaitForSeconds healthCooldown;
        private bool isInvun = false;

        public float gnomeHealth = 10f;

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Awake()
        {
            healthCooldown = new WaitForSeconds(invunTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            // rather basic, it would need to check for the state of the enemy to know if the gnome is being attacked
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!isInvun)
                {
                    StartCoroutine(InvunCo());
                }
            }
        }

        /// <summary>
        /// Reduces player health by 1 and makes it so the gnome can't get hit again until some time has passed.
        /// </summary>
        /// <returns></returns>
        private IEnumerator InvunCo()
        {
            isInvun = true;
            gnomeHealth -= 1f;
            yield return healthCooldown;
            isInvun = false;
        }
    }
}