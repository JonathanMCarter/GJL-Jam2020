using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class FireworksControl : MonoBehaviour
    {
        [SerializeField] private GameObject fireworkPrefab;

        private GameObject instance;

        private void Start()
        {
            instance = Instantiate(fireworkPrefab);
            instance.SetActive(false);
        }

        /// <summary>
        /// Shows a fireworks particle system on hit of another object.
        /// </summary>
        public void HitTarget(GameObject hit)
        {
            instance.transform.position = hit.transform.position;
            instance.SetActive(true);
        }
    }
}