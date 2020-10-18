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
        [SerializeField] private Image weaponImage;
        [SerializeField] private Text weaponNameText;
        [SerializeField] private Text weaponDescText;

        // Things off this object to get
        [SerializeField] private GnomeAttacks gnome;
        private GnomeWeapons activeWeapon;
        private GnomeWeapons lastWeapon;

        // manual update
        private bool shouldUpdate;

        private void Start()
        {
            activeWeapon = gnome.GetActiveWeapon();
            UpdateWeapon(weapons[1]);
        }


        private void Update()
        {
            if (gnome)
            {
                if (!activeWeapon.Equals(lastWeapon) || shouldUpdate)
                {
                    switch (activeWeapon)
                    {
                        case GnomeWeapons.None:
                            break;
                        case GnomeWeapons.FishingRod:

                            UpdateWeapon(weapons[1]);
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
        }


        /// <summary>
        /// Gets up to date values on the active weapon, should only be called when the user changes a weapon...
        /// </summary>
        public void SendUpdatedWeaponStats()
        {
            lastWeapon = activeWeapon;
            activeWeapon = gnome.GetActiveWeapon();
        }


        /// <summary>
        /// Forces the UI to update even if the weapon has not changed.
        /// </summary>
        public void ForceWeaponUIUpdate()
        {
            lastWeapon = activeWeapon;
            activeWeapon = gnome.GetActiveWeapon();
            shouldUpdate = true;
        }


        /// <summary>
        /// Updates the weapon with the new data
        /// </summary>
        /// <param name="newWeapon">WeaponDetails | To change to</param>
        private void UpdateWeapon(WeaponDetails newWeapon)
        {
            weaponImage.sprite = newWeapon.weaponIcon;
            weaponNameText.text = newWeapon.weaponName;
            weaponDescText.text = newWeapon.weaponDesc;
        }
    }
}