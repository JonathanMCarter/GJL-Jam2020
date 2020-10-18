using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.GamePad
{
    public class GamePadButtonPress : MonoBehaviour
    {
        [SerializeField] private Button _toPress;
        [SerializeField] internal bool canPress;
        private GameControls _controls;
        private bool isCoR;

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
            StopAllCoroutines();
        }

        private void Awake()
        {
            _controls = new GameControls();
        }

        private void Update()
        {
            if (canPress && !isCoR)
            {
                if (_controls.Menu.MenuUse.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
                {
                    _toPress.onClick.Invoke();

                    if (gameObject.activeInHierarchy)
                    {
                        StartCoroutine(InputLag());
                    }
                }
            }
        }

        private IEnumerator InputLag()
        {
            isCoR = true;
            yield return new WaitForSeconds(.35f);
            isCoR = false;
        }
    }
}