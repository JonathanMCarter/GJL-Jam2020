using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject toFollow;

        [SerializeField] private bool updateRotation = false;

        private void Update()
        {
            transform.position = toFollow.transform.position;

            if (updateRotation)
            {
                transform.rotation = toFollow.transform.rotation;
            }
        }
    }
}