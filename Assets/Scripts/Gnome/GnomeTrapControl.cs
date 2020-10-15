using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public enum TrapStates { NoTraps, PlaceTrap, PickupTrap };
    public enum TrapTypes { None, Cable, BBQ };

    public class GnomeTrapControl : MonoBehaviour
    {
        [SerializeField] private TrapStates trapState;                  // The state that the gnome is in for placing traps
        [SerializeField] private TrapTypes selectedTrap;                // The currently selected trap 
        [SerializeField] private TrapPlacementArea currentTrapLocation; // the currect trap location to place or remove a trap from

        [SerializeField] private TrapStats[] traps;
        private List<GameObject> trapPool;

        [SerializeField] private TrapTypes trapGnomeOn;

        // input and input lag so the controls don't toggle twice on 1 press.
        private GameControls input;
        private bool canUseInput;
        private bool canUseToggle;
        private WaitForSeconds wait;

        // max ammo and ammo
        internal int maxCableTraps = 3;
        internal int maxBBqTrays = 3;
        internal int cableTraps;
        internal int bbqTrays;


        private void OnEnable()
        {
            input.Enable();
        }


        private void OnDisable()
        {
            input.Disable();
        }


        private void Awake()
        {
            input = new GameControls();
        }


        private void Start()
        {
            trapPool = new List<GameObject>();

            for (int i = 0; i < maxCableTraps; i++)
            {
                GameObject _go = Instantiate(traps[0].prefab);
                _go.name = "* (Trap Pool) - Cable Trap *";
                _go.SetActive(false);
                trapPool.Add(_go);
            }

            for (int i = 0; i < maxBBqTrays; i++)
            {
                GameObject _go = Instantiate(traps[1].prefab);
                _go.name = "* (Trap Pool) - BBQ Trap *";
                _go.SetActive(false);
                trapPool.Add(_go);
            }

            cableTraps = 3;
            bbqTrays = 2;
            canUseInput = true;
            canUseToggle = true;
            wait = new WaitForSeconds(.2f);
        }


        private void Update()
        {
            if (input.Gnome.UseTrap.phase.Equals(InputActionPhase.Performed) && canUseInput)
            {
                if (!trapState.Equals(TrapStates.PickupTrap) && trapState.Equals(TrapStates.PlaceTrap))
                {
                    // place trap down in area.
                    switch (selectedTrap)
                    {
                        case TrapTypes.None:
                            break;
                        case TrapTypes.Cable:

                            if (cableTraps > 0)
                            {
                                PlaceTrap();
                                currentTrapLocation.hasTrap = true;
                                currentTrapLocation.currentTrap = TrapTypes.Cable;
                                cableTraps -= 1;
                            }

                            break;
                        case TrapTypes.BBQ:

                            if (bbqTrays > 0)
                            {
                                PlaceTrap();
                                currentTrapLocation.hasTrap = true;
                                currentTrapLocation.currentTrap = TrapTypes.BBQ;
                                bbqTrays -= 1;
                            }

                            break;
                        default:
                            break;
                    }
                }
                else if (trapState.Equals(TrapStates.PickupTrap) && !trapState.Equals(TrapStates.PlaceTrap))
                {
                    // pick up trap in area.
                    switch (trapGnomeOn)
                    {
                        case TrapTypes.None:
                            break;
                        case TrapTypes.Cable:

                            PickupTrap();
                            currentTrapLocation.hasTrap = false;
                            currentTrapLocation.currentTrap = TrapTypes.None;
                            cableTraps += 1;

                            break;
                        case TrapTypes.BBQ:

                            PickupTrap();
                            currentTrapLocation.hasTrap = false;
                            currentTrapLocation.currentTrap = TrapTypes.None;
                            bbqTrays += 1;

                            break;
                        default:
                            break;
                    }
                }

                // input delay
                StartCoroutine(InputDelay());
            }


            // toggle selected trap 
            if (input.Gnome.ToggleTrap.phase == InputActionPhase.Performed)
            {
                if (canUseToggle)
                {
                    if (selectedTrap.Equals(TrapTypes.Cable))
                    {
                        selectedTrap = TrapTypes.BBQ;
                    }
                    else
                    {
                        selectedTrap = TrapTypes.Cable;
                    }

                    StartCoroutine(InputToggleDelay());
                }
            }
        }



        private void OnTriggerEnter(Collider other)
        {
            // sets up the trap square if the user is on one
            if (other.gameObject.CompareTag("TrapSquare"))
            {
                if (other.gameObject.GetComponent<TrapPlacementArea>())
                {
                    currentTrapLocation = other.gameObject.GetComponent<TrapPlacementArea>();
                    trapGnomeOn = currentTrapLocation.currentTrap;
                }
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("TrapSquare"))
            {
                if (other.gameObject.GetComponent<TrapPlacementArea>() && !currentTrapLocation)
                {
                    currentTrapLocation = other.gameObject.GetComponent<TrapPlacementArea>();
                    trapGnomeOn = currentTrapLocation.currentTrap;
                }

                // check to if there is a trap here...
                // if not allow the user to place a trap here....
                if (currentTrapLocation && !other.gameObject.GetComponent<TrapPlacementArea>().hasTrap)
                {
                    trapState = TrapStates.PlaceTrap;
                }
                else if (currentTrapLocation && other.gameObject.GetComponent<TrapPlacementArea>().hasTrap)
                {
                    // else allow the user to pickup what is there.
                    trapState = TrapStates.PickupTrap;
                }

                // updates the trap location
                if (trapGnomeOn != currentTrapLocation.currentTrap)
                {
                    trapGnomeOn = currentTrapLocation.currentTrap;
                }
            }
        }


        private void OnTriggerExit(Collider other)
        {
            // resets the current trap and gnome state on exit
            if (other.gameObject.CompareTag("TrapSquare"))
            {
                trapState = TrapStates.NoTraps;
                currentTrapLocation = null;
                trapGnomeOn = TrapTypes.None;
            }
        }

        /// <summary>
        /// Adds a little input lag to the user input so they can't spam it twice in one press
        /// </summary>
        private IEnumerator InputDelay()
        {
            canUseInput = false;
            yield return wait;
            canUseInput = true;
        }

        /// <summary>
        /// Adds a little input lag to the toggle of trap types
        /// </summary>
        /// <returns></returns>
        private IEnumerator InputToggleDelay()
        {
            canUseToggle = false;
            yield return wait;
            canUseToggle = true;
        }


        /// <summary>
        /// Place the currently selected trap if possible
        /// </summary>
        private void PlaceTrap()
        {
            switch (selectedTrap)
            {
                case TrapTypes.None:
                    break;
                case TrapTypes.Cable:

                    for (int i = 0; i < trapPool.Count; i++)
                    {
                        if (trapPool[i].tag.Contains("Cable") && !trapPool[i].activeInHierarchy)
                        {
                            trapPool[i].transform.position = currentTrapLocation.transform.position;
                            trapPool[i].transform.SetParent(currentTrapLocation.transform);
                            trapPool[i].SetActive(true);
                            break;
                        }
                    }

                    break;
                case TrapTypes.BBQ:

                    for (int i = 0; i < trapPool.Count; i++)
                    {
                        if (trapPool[i].tag.Contains("BBQ") && !trapPool[i].activeInHierarchy)
                        {
                            trapPool[i].transform.position = currentTrapLocation.transform.position;
                            trapPool[i].transform.SetParent(currentTrapLocation.transform);
                            trapPool[i].SetActive(true);
                            break;
                        }
                    }

                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Pickup the currently selected trap
        /// </summary>
        private void PickupTrap()
        {
            currentTrapLocation.transform.GetChild(0).gameObject.SetActive(false);
            currentTrapLocation.transform.GetChild(0).SetParent(null);
        }


        /// <summary>
        /// TEMP - toggles the trap type selected, gonna make controls for this soon, but this is good for debugging on UI
        /// </summary>
        public void ToggleTrapType()
        {
            if (selectedTrap.Equals(TrapTypes.Cable))
            {
                selectedTrap = TrapTypes.BBQ;
            }
            else
            {
                selectedTrap = TrapTypes.Cable;
            }
        }
    }
}