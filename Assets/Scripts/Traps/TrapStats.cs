using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    [CreateAssetMenu(fileName = "New Trap Stats", menuName = "Oh Gnomes/Trap Stats")]
    public class TrapStats : ScriptableObject
    {
        [SerializeField] public GameObject prefab;
        [SerializeField] public int numberOfUses;
        [SerializeField] public int trapDMG;
        [SerializeField] public GameObject[] extra;
    }
}