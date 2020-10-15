using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class FireworkMove : MonoBehaviour
    {
        [SerializeField] private GameObject fireworkObject;
        [SerializeField] private GameObject fireworkPrefab;
        [Range(30,100)]
        [SerializeField] private float fireworkSpeed = 50f;
        [SerializeField] private float abilityDuration = .75f;

        private bool isCoR;
        private List<GameObject> fireworkPool;
        private GnomeAttacks attacks;
        private WaitForSeconds wait;
        private LineRenderer lr;

        [Header("Ammo Controls")]
        public int ammo = 3;
        public int maxAmmo = 10;


        private void OnEnable()
        {
            wait = new WaitForSeconds(abilityDuration);
            attacks = GetComponent<GnomeAttacks>();
            fireworkObject.SetActive(false);
        }


        private void Awake()
        {
            fireworkPool = new List<GameObject>();

            for (int i = 0; i < 5; i++)
            {
                GameObject _go = Instantiate(fireworkPrefab);
                _go.name = "* (Pool) Firework Missile *";
                _go.SetActive(false);
                fireworkPool.Add(_go);
            }

            lr = fireworkObject.GetComponent<LineRenderer>();
        }


        private void Update()
        {
            if (attacks.GetActiveWeapon().Equals(GnomeWeapons.Firework) && !fireworkObject.activeSelf)
            {
                fireworkObject.SetActive(true);
            }
            else if (!attacks.GetActiveWeapon().Equals(GnomeWeapons.Firework) && fireworkObject.activeSelf)
            {
                fireworkObject.SetActive(false);
            }

            // update line renderer position
            lr.SetPosition(0, fireworkObject.transform.position);
            lr.SetPosition(1, fireworkObject.transform.position + transform.forward * 2);
        }


        public void UseAbility()
        {
            if (!isCoR && ammo > 0)
            {
                StartCoroutine(FireworkAbilityCo());
            }
        }


        private IEnumerator FireworkAbilityCo()
        {
            isCoR = true;

            GameObject _go = GetFireworkMissile();

            if (_go)
            {
                _go.transform.position = fireworkObject.transform.position;
                _go.transform.rotation = fireworkObject.transform.rotation;
                _go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _go.GetComponent<Rigidbody>().velocity += transform.forward * fireworkSpeed;
                _go.SetActive(true);
                ammo -= 1;
            }

            yield return wait;

            isCoR = false;
        }


        private GameObject GetFireworkMissile()
        {
            for (int i = 0; i < fireworkPool.Count; i++)
            {
                if (!fireworkPool[i].activeInHierarchy)
                {
                    return fireworkPool[i];
                }
            }

            return null;
        }
    }
}