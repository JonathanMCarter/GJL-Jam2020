using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private WeaponDetails[] weapons;

        // Things on this object to get
        private Image weaponImage;
        private Text weaponNameText;
        private Text weaponDescText;

        // Things off this object to get
        private GnomeAttacks gnome;
        private GnomeWeapons activeWeapon;
        private GnomeWeapons lastWeapon;
        private FishingRodAttack activeRodAttackType;

        // manual update
        private bool shouldUpdate;

        private void Start()
        {
            weaponImage = GetComponentInChildren<Image>();
            weaponNameText = GetComponentsInChildren<Text>()[0];
            weaponDescText = GetComponentsInChildren<Text>()[1];

            gnome = GameObject.FindGameObjectWithTag("Player").GetComponent<GnomeAttacks>();
            activeWeapon = gnome.GetActiveWeapon();
            activeRodAttackType = gnome.gameObject.GetComponent<FishingRodMove>().rodAttackType;

            UpdateWeapon(weapons[1]);
        }


        private void Update()
        {
            if (!activeWeapon.Equals(lastWeapon) || shouldUpdate)
            {
                switch (activeWeapon)
                {
                    case GnomeWeapons.None:
                        break;
                    case GnomeWeapons.FishingRod:

                       
                        // update based on the attack style...
                        switch (activeRodAttackType)
                        {
                            case FishingRodAttack.Melee:

                                UpdateWeapon(weapons[0]);

                                break;
                            case FishingRodAttack.Ranged:

                                UpdateWeapon(weapons[1]);

                                break;
                            default:
                                break;
                        }


                        break;
                    case GnomeWeapons.Umbrella:

                        UpdateWeapon(weapons[2]);

                        break;
                    case GnomeWeapons.Firework:

                        UpdateWeapon(weapons[3]);

                        break;
                    default:
                        break;
                }

                if (shouldUpdate)
                {
                    shouldUpdate = false;
                }
            }
        }


        /// <summary>
        /// Gets up to date values on the active weapon, should only be called when the user changes a weapon...
        /// </summary>
        public void SendUpdatedWeaponStats()
        {
            lastWeapon = activeWeapon;
            activeWeapon = gnome.GetActiveWeapon();
            activeRodAttackType = gnome.gameObject.GetComponent<FishingRodMove>().rodAttackType;
        }


        /// <summary>
        /// Forces the UI to update even if the weapon has not changed.
        /// </summary>
        public void ForceWeaponUIUpdate()
        {
            lastWeapon = activeWeapon;
            activeWeapon = gnome.GetActiveWeapon();
            activeRodAttackType = gnome.gameObject.GetComponent<FishingRodMove>().rodAttackType;
            shouldUpdate = true;
        }


        /// <summary>
        /// Updates the weapon with the new data
        /// </summary>
        /// <param name="newWeapon">WeaponDetails | To change to</param>
        private void UpdateWeapon(WeaponDetails newWeapon)
        {
            if (!weaponImage.sprite.Equals(newWeapon.weaponIcon))
            {
                weaponImage.sprite = newWeapon.weaponIcon;
            }

            if (!weaponNameText.text.Equals(newWeapon.weaponName))
            {
                weaponNameText.text = newWeapon.weaponName;
            }

            if (!weaponDescText.text.Equals(newWeapon.weaponDesc))
            {
                weaponDescText.text = newWeapon.weaponDesc;
            }
        }
    }
}