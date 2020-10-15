using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

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
        private bool canMove = true;
        private CanvasGroup cGroup;
        private GameControls input;

        // Controller input options
        [SerializeField] private Image[] selectionImage;
        private int pos = 0;
        private int maxPos;

        private Color32[] colours = new Color32[2];


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
            colours[0] = new Color32(163, 163, 51, 255);
            colours[1] = selectionImage[0].color;
            maxPos = selectionImage.Length - 1;
        }


        private void Update()
        {
            if (input.Menu.PauseGame.phase == InputActionPhase.Performed && canPause)
            {
                isGamePaused = !isGamePaused;
                StartCoroutine(PauseInputLag());
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

            if (Gamepad.all.Count > 0)
            {
                if (Gamepad.current.enabled)
                {
                    for (int i = 0; i < selectionImage.Length; i++)
                    {
                        if (i.Equals(pos))
                        {
                            selectionImage[i].color = colours[0];
                        }
                        else if (!selectionImage[i].color.Equals(colours[1]))
                        {
                            selectionImage[i].color = colours[1];
                        }
                    }
                }
            }

            // controller input for menu
            if (isGamePaused)
            {
                if (input.Menu.MenuUD.ReadValue<float>() > .5f)
                {
                    if (canMove)
                    {
                        if ((pos + 1).Equals(maxPos))
                        {
                            pos = maxPos;
                        }
                        else
                        {
                            pos = 0;
                        }



                        StartCoroutine(MoveInputLag());
                    }
                }
                else if (input.Menu.MenuUD.ReadValue<float>() < -.5f)
                {
                    if (canMove)
                    {
                        if ((pos - 1).Equals(-1))
                        {
                            pos = maxPos;
                        }
                        else
                        {
                            pos -= 1;
                        }

                        StartCoroutine(MoveInputLag());
                    }
                }
            }


            if (input.Menu.MenuUse.phase == InputActionPhase.Performed)
            {
                selectionImage[pos].GetComponent<Button>().onClick.Invoke();
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

            for (int i = 0; i < selectionImage.Length; i++)
            {
                selectionImage[i].color = colours[1];
            }
        }


        public void ToMenu()
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }


        private IEnumerator PauseInputLag()
        {
            canPause = false;
            yield return new WaitForSeconds(.5f);
            canPause = true;
        }


        private IEnumerator MoveInputLag()
        {
            canMove = false;

            for (int i = 0; i < selectionImage.Length; i++)
            {
                if (i.Equals(pos))
                {
                    selectionImage[i].color = colours[0];
                }
                else if (!selectionImage[i].color.Equals(colours[1]))
                {
                    selectionImage[i].color = colours[1];
                }
            }

            yield return new WaitForSecondsRealtime(.5f);
            canMove = true;
        }
    }
}