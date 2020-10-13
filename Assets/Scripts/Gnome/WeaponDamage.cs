using System.Collections;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private GnomeWeapons weapon;

        [SerializeField] private Gnome gnomeStats;
        [SerializeField] private FishingRodAttack rodType;
        [SerializeField] private int dmg;
        [SerializeField] private bool canDamage;

        private DamageIndicator ind;


        private void OnEnable()
        {
            canDamage = true;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Start()
        {
            gnomeStats = FindObjectOfType<GnomeStats>().GetGnomeStats();

            if (weapon.Equals(GnomeWeapons.Firework))
            {
                dmg = gnomeStats.fireworkDamage;
            }

            canDamage = true;

            if (weapon.Equals(GnomeWeapons.FishingRod))
            {
                switch (rodType)
                {
                    case FishingRodAttack.Melee:
                        dmg = gnomeStats.fishingRodMeleeDamage;
                        break;
                    case FishingRodAttack.Ranged:
                        dmg = gnomeStats.fishingRodRangedDamage;
                        break;
                    default:
                        break;
                }
            }

            ind = FindObjectOfType<DamageIndicator>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (canDamage)
            {
                if (other.gameObject.GetComponent<BaseEnemyBehaviour>())
                {
                    // deals damage to enemy
                    other.gameObject.GetComponent<BaseEnemyBehaviour>().ReduceEnemyHealth(dmg);

                    // dmg indicator
                    ind.ShowDMGIndicator(new Vector3(other.transform.position.x, other.transform.position.y + 1.5f, other.transform.position.z), dmg, Color.green);

                    if (weapon.Equals(GnomeWeapons.Firework))
                    {
                        gameObject.SetActive(false);
                    }

                    switch (weapon)
                    {
                        case GnomeWeapons.None:
                            break;
                        case GnomeWeapons.FishingRod:

                            switch (rodType)
                            {
                                case FishingRodAttack.Melee:
                                    StartCoroutine(DamageCooldown(gnomeStats.fishingRodMeleeDamageCooldown));
                                    break;
                                case FishingRodAttack.Ranged:
                                    StartCoroutine(DamageCooldown(gnomeStats.fishingRodRangedDamageCooldown));
                                    break;
                                default:
                                    break;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private IEnumerator DamageCooldown(float delay)
        {
            canDamage = false;
            yield return new WaitForSeconds(delay);
            canDamage = true;
        }
    }
}