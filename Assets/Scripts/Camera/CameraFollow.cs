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

        private void Update()
        {
            transform.position = toFollow.transform.position;
        }
    }
}