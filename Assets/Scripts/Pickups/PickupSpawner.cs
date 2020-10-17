using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class PickupSpawner : MonoBehaviour
    {
        [SerializeField] private int[] minMaxTime;
        [SerializeField] private int numberOfPickups;
        [SerializeField] private GameObject pickupPrefab;

        private GameObject[] pickupsPool;
        [SerializeField] private TrapPlacementArea[] placementPoints;
        private bool isCoR;

        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Start()
        {
            pickupsPool = new GameObject[numberOfPickups];

            for (int i = 0; i < numberOfPickups; i++)
            {
                GameObject _go = Instantiate(pickupPrefab);
                _go.name = "* (Pool) Pickup *";
                _go.SetActive(false);
                pickupsPool[i] = _go;
            }

            placementPoints = FindObjectsOfType<TrapPlacementArea>();
        }


        private void Update()
        {
            if (!isCoR)
            {
                StartCoroutine(SpawnPickup());
            }
        }


        private IEnumerator SpawnPickup()
        {
            isCoR = true;

            yield return new WaitForSeconds(Random.Range(minMaxTime[0], minMaxTime[1]));

            for (int i = 0; i < numberOfPickups; i++)
            {
                if (!pickupsPool[i].activeInHierarchy)
                {
                    Transform _t = GetSpawnPoint();

                    if (_t)
                    {
                        pickupsPool[i].transform.position = _t.position;
                        pickupsPool[i].SetActive(true);
                    }

                    break;
                }
            }

            isCoR = false;
        }



        /// <summary>
        /// Retruns a free trap spot to place the pickup.
        /// </summary>
        /// <returns>Transform of the spawn point that is free of traps.</returns>
        private Transform GetSpawnPoint()
        {
            // Checks to see if there is a free spot, if not it avoids the while loop (which will cause a leak, crashing Unity)
            if (IsFreeSpot())
            {
                TrapPlacementArea _trap = placementPoints[Random.Range(0, placementPoints.Length)];

                while (_trap.hasTrap)
                {
                    _trap = placementPoints[Random.Range(0, placementPoints.Length)];
                }

                return _trap.transform;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Checks to see if there is a free spot to spawn an object.
        /// </summary>
        /// <returns>true or false</returns>
        private bool IsFreeSpot()
        {
            int _check = 0;

            for (int i = 0; i < placementPoints.Length; i++)
            {
                if (!placementPoints[i].hasTrap)
                {
                    _check += 1;
                }
            }

            if (_check.Equals(placementPoints.Length))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}