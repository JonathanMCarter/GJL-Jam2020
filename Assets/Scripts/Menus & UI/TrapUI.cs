using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class TrapUI : MonoBehaviour
    {
        [SerializeField] private GameObject trapUIPrefab;

        private GameObject prefabInstance;
        private bool isGamepad;

        private const string keyboardPlace = "Press E to place trap";
        private const string keyboardPickup = "Press E to pickup trap";
        private const string keyboardToggle = "Press R to toggle trap type";
        private const string controllerPlace = "Press RT to place trap";
        private const string controllerPickup = "Press RT to pickup trap";
        private const string controllerToggle = "Press RB to toggle trap type";

        // gnome trap
        private GnomeTrapControl playerTraps;

        private void Start()
        {
            prefabInstance = Instantiate(trapUIPrefab, transform);
            prefabInstance.SetActive(false);

            playerTraps = GameObject.FindGameObjectWithTag("Player").GetComponent<GnomeTrapControl>();
        }


        private void Update()
        {
            if (Gamepad.all.Count > 0)
            {
                isGamepad = true;
            }
            else
            {
                isGamepad = false;
            }


            if (playerTraps.GetCurrentTrap())
            {
                if (playerTraps.bbqTrays.Equals(0) && playerTraps.cableTraps.Equals(0) && !playerTraps.GetCurrentTrap().hasTrap)
                {
                    HideTrapUI();
                }
            }
        }


        /// <summary>
        /// Updates the trap UI
        /// </summary>
        /// <param name="state">The state of the trap</param>
        /// <param name="type">The type of trap on the trap currently</param>
        /// <param name="userTrap">The trap type the user has active</param>
        public void UpdateTrapUIDetails(TrapStates state, TrapTypes type, TrapTypes userTrap)
        {
            if (state.Equals(TrapStates.PlaceTrap))
            {
                prefabInstance.GetComponentsInChildren<Text>()[0].text = "Place " + userTrap.ToString() + " Trap";
            }
            else if (state.Equals(TrapStates.PickupTrap))
            {
                prefabInstance.GetComponentsInChildren<Text>()[0].text = "Pickup " + type.ToString() + " Trap";
            }

            prefabInstance.GetComponentsInChildren<Text>()[1].text = userTrap.ToString() + " Trap Selected";

            if (isGamepad)
            {
                if (state.Equals(TrapStates.PlaceTrap))
                {
                    prefabInstance.GetComponentsInChildren<Text>()[2].text = controllerPlace;
                }
                else if (state.Equals(TrapStates.PickupTrap))
                {
                    prefabInstance.GetComponentsInChildren<Text>()[2].text = controllerPickup;
                }

                prefabInstance.GetComponentsInChildren<Text>()[3].text = controllerToggle;
            }
            else
            {
                if (state.Equals(TrapStates.PlaceTrap))
                {
                    prefabInstance.GetComponentsInChildren<Text>()[2].text = keyboardPlace;
                }
                else if (state.Equals(TrapStates.PickupTrap))
                {
                    prefabInstance.GetComponentsInChildren<Text>()[2].text = keyboardPickup;
                }

                prefabInstance.GetComponentsInChildren<Text>()[3].text = keyboardToggle;
            }
        }


        /// <summary>
        /// Shows the trap UI if its not already visable
        /// </summary>
        /// <param name="_transform">where to show it</param>
        public void DisplayTrapUI(Transform _transform)
        {
            if (!prefabInstance.activeInHierarchy)
            {
                prefabInstance.transform.position = _transform.position;
                prefabInstance.SetActive(true);
            }
        }


        /// <summary>
        /// Hides the trap UI
        /// </summary>
        public void HideTrapUI()
        {
            prefabInstance.SetActive(false);
        }
    }
}