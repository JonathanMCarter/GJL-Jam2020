using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using CarterGames.Utilities;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class Sun : MonoBehaviour
    {
        [SerializeField] private int sunhealth = 30;
        [SerializeField] private Slider sunHealthBar;

        private Color defaultBarCol;
        private WaitForSeconds wait;
        private Image barColor;
        private CameraShakeScript cam;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Start()
        {
            wait = new WaitForSeconds(.1f);
            sunHealthBar.maxValue = sunhealth;
            sunHealthBar.value = sunhealth;
            barColor = sunHealthBar.GetComponentsInChildren<Image>()[1];
            defaultBarCol = barColor.color;
            cam = FindObjectOfType<CameraShakeScript>();
        }


        private void Update()
        {
            if (!sunHealthBar.value.Equals(sunHealthBar))
            {
                sunHealthBar.value = sunhealth;
            }

            if (sunhealth <= 0)
            {
                // sun deded......
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EnemyAttack"))
            {
                DamageSun(1);
            }
        }


        private IEnumerator HealthbarFlicker()
        {
            barColor.color = Color.white;
            cam.ShakeCamera(false, .1f, .25f);
            yield return wait;
            barColor.color = defaultBarCol;
        }


        public void DamageSun(int dmg)
        {
            sunhealth -= dmg;
            StartCoroutine(HealthbarFlicker());
        }
    }
}