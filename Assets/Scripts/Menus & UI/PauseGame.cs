using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class PauseGame : MonoBehaviour
    {
        private bool isGamePaused;
        private bool canPause = true;
        private CanvasGroup cGroup;
        private GameControls input;


        private void OnEnable()
        {
            input.Enable();
        }


        private void OnDisable()
        {
            input.Disable();
            StopAllCoroutines();
        }


        private void Awake()
        {
            input = new GameControls();
            cGroup = GetComponent<CanvasGroup>();
        }


        private void Update()
        {
            if (input.Menu.PauseGame.phase == InputActionPhase.Performed && canPause)
            {
                isGamePaused = !isGamePaused;
                StartCoroutine(InputLag());
            }

            if (isGamePaused)
            {
                if (Time.timeScale.Equals(1))
                {
                    Time.timeScale = 0;
                }

                FadeInOutCanvasUI();
            }
            else
            {
                if (Time.timeScale.Equals(0))
                {
                    Time.timeScale = 1;
                }

                FadeInOutCanvasUI();
            }
        }


        private void FadeInOutCanvasUI()
        {
            if (isGamePaused && !cGroup.alpha.Equals(1))
            {
                cGroup.alpha += Time.unscaledDeltaTime * 4;
                cGroup.interactable = true;
                cGroup.blocksRaycasts = true;
            }
            else if (!isGamePaused && !cGroup.alpha.Equals(0))
            {
                cGroup.alpha -= Time.unscaledDeltaTime * 4;
                cGroup.interactable = false;
                cGroup.blocksRaycasts = false;
            }
        }


        public void ResumeGame()
        {
            isGamePaused = false;
        }


        public void ToMenu()
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }


        private IEnumerator InputLag()
        {
            canPause = false;
            yield return new WaitForSeconds(.5f);
            canPause = true;
        }
    }
}