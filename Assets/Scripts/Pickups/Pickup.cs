using CarterGames.Utilities;
using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private int fireworksAmmo;
        [SerializeField] private int eTrap;
        [SerializeField] private int bTrap;
        [SerializeField] private int[] minMax;
        [SerializeField] private int[] minMaxTraps;


        private void Start()
        {
            fireworksAmmo = Random.Range(minMax[0], minMax[1]);
            bTrap = Random.Range(minMaxTraps[0], minMaxTraps[1]);
            eTrap = Random.Range(minMaxTraps[0], minMaxTraps[1]);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<FireworkMove>().ammo + fireworksAmmo < other.gameObject.GetComponent<FireworkMove>().maxAmmo)
                {
                    other.gameObject.GetComponent<FireworkMove>().ammo += fireworksAmmo;
                }

                if (other.gameObject.GetComponent<GnomeTrapControl>().cableTraps + eTrap < other.gameObject.GetComponent<GnomeTrapControl>().maxCableTraps)
                {
                    other.gameObject.GetComponent<GnomeTrapControl>().cableTraps += eTrap;
                }

                if (other.gameObject.GetComponent<GnomeTrapControl>().bbqTrays + bTrap < other.gameObject.GetComponent<GnomeTrapControl>().maxBBqTrays)
                {
                    other.gameObject.GetComponent<GnomeTrapControl>().bbqTrays += bTrap;
                }

                gameObject.SetActive(false);
            }
        }
    }
}