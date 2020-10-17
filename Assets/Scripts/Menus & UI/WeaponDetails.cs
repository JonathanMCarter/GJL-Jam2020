using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Weapon Details", menuName = "Oh Gnomes/Weapon Details")]
    public class WeaponDetails : ScriptableObject
    {
        public Sprite weaponIcon;
        public string weaponName;
        public string weaponDesc;
    }
}