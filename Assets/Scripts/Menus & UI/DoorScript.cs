using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class DoorScript : MonoBehaviour
    {

        private Animator anim;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("OpenDoor");
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("CloseDoor");
            }
        }
    }
}