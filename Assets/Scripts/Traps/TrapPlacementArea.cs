using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class TrapPlacementArea : MonoBehaviour
    {
        public TrapTypes currentTrap;
        public bool hasTrap;


        private void Start()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}