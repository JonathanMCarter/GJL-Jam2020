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
        [SerializeField] private float weaponCooldown = .75f;

        private bool isCoR;
        private List<GameObject> fireworkPool;
        private GnomeAttacks attacks;
        private WaitForSeconds wait;


        private void OnEnable()
        {
            wait = new WaitForSeconds(weaponCooldown);
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
        }


        public void UseAbility()
        {
            if (!isCoR)
            {
                StartCoroutine(FireworkAbilityCo());
            }
        }


        private IEnumerator FireworkAbilityCo()
        {
            isCoR = true;

            GameObject _go = GetFireworkMissile();
            _go.transform.position = fireworkObject.transform.position;
            _go.transform.rotation = fireworkObject.transform.rotation;
            _go.GetComponent<Rigidbody>().velocity += transform.forward * fireworkSpeed;
            _go.SetActive(true);

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