using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class FishingRodMove : MonoBehaviour
    {
        [SerializeField] private GameObject fishingRodObject;
        private GnomeAttacks attacks;

        private void OnEnable()
        {
            attacks = GetComponent<GnomeAttacks>();
            fishingRodObject.SetActive(false);
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
        }

        public void UseAbility()
        {
            // would play an animation, for now its gonna move to a position and do something
        }
    }
}