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
        [SerializeField] private float dmg;

        private void OnTriggerEnter(Collider other)
        {
            // damage opponent...
        }
    }
}