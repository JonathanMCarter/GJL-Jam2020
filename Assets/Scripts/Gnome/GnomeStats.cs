using DresslikeaGnome.OhGnomes.Audio;
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
        private int maxGnomeHealth;
        private DamageIndicator ind;
        [SerializeField] private Image barColor;
        [SerializeField] private Color defaultBarCol;
        private Animator anim;

        internal bool isInvun = false;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Awake()
        {
            healthCooldown = new WaitForSeconds(invunTime);

            gnomeHealth = gnomeStats.health;
            maxGnomeHealth = gnomeStats.health;

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

            anim = GetComponentInChildren<Animator>();
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

            if (gnomeHealth <= 0)
            {
                anim.SetTrigger("IsDead");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // The enemy attack collider is only activated during the attack animation so we can safely say when the enemy is actually hitting ht egnome
            if (other.gameObject.CompareTag("EnemyAttack"))
            {
                anim.SetTrigger("IsHit");

                if (!isInvun)
                {
                    StartCoroutine(InvunCo());
                }
            }
            
            //easier to have the gnome decide if he's being healed rather than having to reach from the healing zone to here
            if (other.gameObject.CompareTag("HealingZone"))
            {
                StartHealing();
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.gameObject.CompareTag("HealingZone"))
            {
                StopHealing();
            }
        }
        

        /// <summary>
        /// Reduces player health by 1 and makes it so the gnome can't get hit again until some time has passed.
        /// </summary>
        /// <returns></returns>
        private IEnumerator InvunCo()
        {
            isInvun = true;
            GetComponentInChildren<GnomeHurt>().PlayHurtSound();
            gnomeHealth -= 1;
            ind.ShowDMGIndicator(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), 1, Color.red);
            StartCoroutine(HealthbarFlicker());
            yield return healthCooldown;
            isInvun = false;
        }


        private void HealingCo()
        {
            gnomeHealth += 1;
            ind.ShowDMGIndicator(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), 1, Color.green);
            StartCoroutine(HealthbarFlicker());
        }

        //we want to heal the gnome BUT not too much
        private void StartHealing()
        {
            if (gnomeHealth < maxGnomeHealth)
                InvokeRepeating("HealingCo", 0.1f, 1);
            else
                CancelInvoke("HealingCo");

        }

        private void StopHealing()
        {
            CancelInvoke("HealingCo");
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
        /// <returns>Gnome | the default stats for the gnome</returns>
        public Gnome GetGnomeStats()
        {
            return gnomeStats;
        }


        /// <summary>
        /// Returns the gnome health
        /// </summary>
        /// <returns>Int | gnome health</returns>
        public int GetGnomeHealth()
        {
            return gnomeHealth;
        }
    }
}