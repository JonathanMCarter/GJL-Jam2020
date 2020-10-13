using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    [CreateAssetMenu(fileName = "New Gnome", menuName = "Oh Gnomes/Gnome")]
    public class Gnome : ScriptableObject
    {
        [SerializeField] public int health;
        [SerializeField] public int fishingRodMeleeDamage;
        [SerializeField] public int fishingRodRangedDamage;
        [SerializeField] public int fireworkDamage;
        [SerializeField] public float fishingRodMeleeDamageCooldown;
        [SerializeField] public float fishingRodRangedDamageCooldown;
    }
}