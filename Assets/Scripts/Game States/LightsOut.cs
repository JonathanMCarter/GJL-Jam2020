﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class LightsOut : MonoBehaviour
    {
        private Light[] roomLights;
        private Sun theSun;
        private Animator anim;
        private bool isCoR;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Start()
        {
            roomLights = FindObjectsOfType<Light>();
            anim = GetComponent<Animator>();
            theSun = GameObject.FindGameObjectWithTag("SunTarget").GetComponent<Sun>();
        }


        private void Update()
        {
            if (theSun.GetHealth() <= 0)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Trigger the lights to go and the scene to fade out.
        /// </summary>
        public void GameOver()
        {
            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].enabled = false;
                anim.SetTrigger("GameOver");
                
                if (!isCoR)
                {
                    StartCoroutine(ChangeToLoseScreen());
                }
            }
        }


        private IEnumerator ChangeToLoseScreen()
        {
            isCoR = true;
            yield return new WaitForSeconds(4f);
            SceneManager.LoadSceneAsync("Lose Scene");
        }
    }
}