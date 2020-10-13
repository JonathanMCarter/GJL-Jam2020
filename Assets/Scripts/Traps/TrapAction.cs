using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class TrapAction : MonoBehaviour
    {
        [SerializeField] private TrapStats trap;

        private int usesLeft;


        private void Start()
        {
            usesLeft = trap.numberOfUses;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                // do damage to them and use a use....
            }
        }
    }
}