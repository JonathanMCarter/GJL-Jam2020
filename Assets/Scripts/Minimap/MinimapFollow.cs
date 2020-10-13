using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class MinimapFollow : MonoBehaviour
    {
        [SerializeField] private GameObject toFollow;

        private void LateUpdate()
        {
            transform.position = toFollow.transform.position;
        }
    }
}