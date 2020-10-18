using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using CarterGames.Utilities;
using DresslikeaGnome.OhGnomes.Audio;

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
        private DamageIndicator ind;
        [SerializeField] private Light _light;
        private int[] healthPercentages = new int[3];
        private Material sunMat;
        private MusicCrossfade music;

        [SerializeField] private GameObject soundPrefab;
        [SerializeField] private AudioClip sunDeath;
        private bool hasDeath;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void OnEnable()
        {
            hasDeath = false;
        }


        private void Start()
        {
            wait = new WaitForSeconds(.1f);
            sunHealthBar.maxValue = sunhealth;
            sunHealthBar.value = sunhealth;
            barColor = sunHealthBar.GetComponentsInChildren<Image>()[1];
            defaultBarCol = barColor.color;
            ind = FindObjectOfType<DamageIndicator>();

            // health percentages
            healthPercentages[0] = (sunhealth / 4) * 3;
            healthPercentages[1] = (sunhealth / 4) * 2;
            healthPercentages[2] = (sunhealth / 4);

            // sun material
            sunMat = GetComponent<Renderer>().material;

            music = FindObjectOfType<MusicCrossfade>();

            music.ResetIntensity();
        }


        private void Update()
        {
            if (!sunHealthBar.value.Equals(sunHealthBar))
            {
                sunHealthBar.value = sunhealth;
            }

            if (sunhealth <= 0)
            {
                gameObject.SetActive(false);

                // play the sound for hit
                if (hasDeath)
                {
                    GameObject clip = Instantiate(soundPrefab);
                    clip.GetComponent<AudioSource>().clip = sunDeath;
                    clip.GetComponent<AudioSource>().volume = Random.Range(.8f, 1f);
                    clip.GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
                    clip.GetComponent<AudioSource>().Play();
                    Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
                    hasDeath = true;
                }
            }

            // changes the brightness settings
            ChangeBrightness();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EnemyAttack"))
            {
                GetComponent<SunHit>().PlaySunHit();
                DamageSun(1);
                ind.ShowDMGIndicator(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), 1, Color.yellow);
            }
        }


        private IEnumerator HealthbarFlicker()
        {
            barColor.color = Color.white;
            yield return wait;
            barColor.color = defaultBarCol;
        }


        public void DamageSun(int dmg)
        {
            sunhealth -= dmg;
            StartCoroutine(HealthbarFlicker());
        }

        /// <summary>
        /// Changes the brightnesses of the sun
        /// </summary>
        private void ChangeBrightness()
        {
            // 25% health
            if (sunhealth < healthPercentages[2])
            {
                sunMat.SetFloat("_brightness", 1);
                _light.intensity = 2.5f;
                _light.range = 2.5f;
                music.IncreaseIntensity();
            }
            // 50% health
            else if (sunhealth < healthPercentages[1])
            {
                sunMat.SetFloat("_brightness", 1.75f);
                _light.intensity = 5f;
                _light.range = 5f;
            }
            // 75% health
            else if (sunhealth < healthPercentages[0])
            {
                sunMat.SetFloat("_brightness", 2.25f);
                _light.intensity = 7.5f;
                _light.range = 7.5f;
                music.IncreaseIntensity();
            }
            // 100% health
            else
            {
                sunMat.SetFloat("_brightness", 3);
                _light.intensity = 10f;
                _light.range = 10f;
            }
        }


        /// <summary>
        /// Returns the current health of the sun
        /// </summary>
        /// <returns>The sunHealth variable</returns>
        public int GetHealth()
        {
            return sunhealth;
        }
    }
}