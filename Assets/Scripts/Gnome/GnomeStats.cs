using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class GnomeStats : MonoBehaviour
    {
        [SerializeField] private Gnome gnomeStats;
        [SerializeField] private float invunTime = .5f;
        [SerializeField] private Slider gnomeHealthbar;

        private WaitForSeconds healthCooldown;
        [SerializeField] private int gnomeHealth;
        private DamageIndicator ind;
        [SerializeField] private Image barColor;
        [SerializeField] private Color defaultBarCol;

        internal bool isInvun = false;


        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Awake()
        {
            healthCooldown = new WaitForSeconds(invunTime);

            gnomeHealth = gnomeStats.health;

            if (gnomeHealthbar)
            {
                gnomeHealthbar.value = gnomeHealth;
                gnomeHealthbar.maxValue = gnomeHealth;
                barColor = gnomeHealthbar.GetComponentsInChildren<Image>()[1];
                defaultBarCol = barColor.color;
            }

            if (FindObjectOfType<DamageIndicator>())
            {
                ind = FindObjectOfType<DamageIndicator>();
            }
        }


        private void Update()
        {
            if (gnomeHealthbar)
            {
                if (!gnomeHealthbar.value.Equals(gnomeHealth))
                {
                    gnomeHealthbar.value = gnomeHealth;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // rather basic, it would need to check for the state of the enemy to know if the gnome is being attacked
            if (other.gameObject.CompareTag("EnemyAttack"))
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
            gnomeHealth -= 1;
            ind.ShowDMGIndicator(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), 1, Color.blue);
            StartCoroutine(HealthbarFlicker());
            yield return healthCooldown;
            isInvun = false;
        }



        private IEnumerator HealthbarFlicker()
        {
            barColor.color = Color.white;
            yield return new WaitForSeconds(.1f);
            barColor.color = defaultBarCol;
        }


        /// <summary>
        /// Returns the gnome stats for use elsewhere.
        /// </summary>
        /// <returns></returns>
        public Gnome GetGnomeStats()
        {
            return gnomeStats;
        }
    }
}