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
        private GameControls _controls;

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Awake()
        {
            _controls = new GameControls();
        }

        private void Update()
        {
            if (_controls.Menu.MenuUse.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            {
                _toPress.onClick.Invoke();
            }
        }
    }
}