using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.GamePad
{
    public class GamepadMenu : MonoBehaviour
    {
        [SerializeField] private Image[] selectionImage;
        private int pos = 0;
        private int maxPos;
        private Color32[] colours = new Color32[2];
        private GameControls input;
        private bool canMove;


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
        }


        private void Start()
        {
            canMove = true;
            maxPos = selectionImage.Length - 1;
            colours[0] = new Color32(163, 163, 51, 255);
            colours[1] = selectionImage[0].color;
        }


        private void Update()
        {
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

            if (input.Menu.MenuUse.phase == InputActionPhase.Performed)
            {
                selectionImage[pos].GetComponent<Button>().onClick.Invoke();
            }
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