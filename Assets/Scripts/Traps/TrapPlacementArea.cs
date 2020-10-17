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
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<GnomeTrapControl>().bbqTrays > 0 || other.gameObject.GetComponent<GnomeTrapControl>().cableTraps > 0 || hasTrap)
                {
                    GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (GetComponent<MeshRenderer>())
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}