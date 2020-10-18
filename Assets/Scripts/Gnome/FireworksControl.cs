using DresslikeaGnome.OhGnomes.Audio;
using System;
using System.Collections.Generic;
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
        [SerializeField] private GameObject[] fireworkPool;


        private void Start()
        {
            fireworkPool = new GameObject[3];

            for (int i = 0; i < fireworkPool.Length; i++)
            {
                GameObject _go = Instantiate(fireworkPrefab);
                _go.name = "* (Pool) Firework Hit *";
                _go.SetActive(false);
                fireworkPool[i] = _go;
            }
        }

        /// <summary>
        /// Shows a fireworks particle system on hit of another object.
        /// </summary>
        public void HitTarget(GameObject hit)
        {
            for (int i = 0; i < fireworkPool.Length; i++)
            {
                if (!fireworkPool[i].activeInHierarchy)
                {
                    GetComponent<Fireworks>().PlayFireworkHit();
                    fireworkPool[i].transform.position = hit.transform.position;
                    fireworkPool[i].SetActive(true);
                    break;
                }
            }
        }
    }
}