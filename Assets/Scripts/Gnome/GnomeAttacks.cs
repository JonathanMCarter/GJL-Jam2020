using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using CarterGames.Utilities;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public enum GnomeWeapons { None, FishingRod, Umbrella, Firework };

    [RequireComponent(typeof(FishingRodMove), typeof(UmbrellaMove), typeof(FireworkMove))]
    public class GnomeAttacks : MonoBehaviour
    {
        [SerializeField] private GnomeWeapons activeWeapon;
        [SerializeField] private Camera cam;
        [SerializeField] private GraphicRaycaster graphicsRaycaster;


        [SerializeField] private float coolDown;
        private WaitForSeconds wait;

        private bool isCoR;
        private bool canUseWeapon;
        private bool canToggle;

        private GameControls input;
        private FishingRodMove rodAttack;
        private UmbrellaMove umbrellaAttack;
        private FireworkMove fireworkAttack;
        [SerializeField] private WeaponUI weaponUI;


        internal Animator anim;

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
            anim = GetComponentsInChildren<Animator>()[1];
            wait = new WaitForSeconds(coolDown);
        }

        private void Start()
        {
            rodAttack = GetComponent<FishingRodMove>();
            umbrellaAttack = GetComponent<UmbrellaMove>();
            fireworkAttack = GetComponent<FireworkMove>();
            canToggle = true;
        }


        private void Update()
        {
            ToggleActiveWeapon();

            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Code to be place in a MonoBehaviour with a GraphicRaycaster component
                GraphicRaycaster gr = graphicsRaycaster;
                //Create the PointerEventData with null for the EventSystem
                PointerEventData ped = new PointerEventData(null);
                //Set required parameters, in this case, mouse position
                ped.position = Mouse.current.position.ReadValue();
                //Create list to receive all results
                List<RaycastResult> results = new List<RaycastResult>();
                //Raycast it
                gr.Raycast(ped, results);

                if (results.Count.Equals(0))
                {
                    canUseWeapon = true;
                }
                else
                {
                    // checks to see if the layer of any object is the user UI layer
                    if (!Check.LayerCheck(results, LayerMask.NameToLayer("UserUI")))
                    {
                        canUseWeapon = true;
                    }
                    else
                    {
                        canUseWeapon = false;
                    }
                }
            }


            // if the user is not over some user UI (can use MB)
            if (canUseWeapon)
            {
                if (input.Gnome.Attack.phase == InputActionPhase.Performed)
                {
                    UseActiveWeapon();
                }

                if (canToggle)
                {
                    if (input.Gnome.WeaponToggle.phase == InputActionPhase.Performed && activeWeapon.Equals(GnomeWeapons.FishingRod))
                    {
                        ToggleFishingRod();
                    }
                }
            }
        }

        /// <summary>
        /// Runs the action for each ability
        /// </summary>
        private void UseActiveWeapon()
        {
            if (!isCoR)
            {
                // use ability
                switch (activeWeapon)
                {
                    case GnomeWeapons.None:
                        break;
                    case GnomeWeapons.FishingRod:

                        UseFishingRod();

                        // cooldown before next use
                        StartCoroutine(WeaponCooldownCo());
                        break;
                    case GnomeWeapons.Umbrella:

                        UseUmbrella();

                        // cooldown before next use
                        StartCoroutine(WeaponCooldownCo());
                        break;
                    case GnomeWeapons.Firework:

                        UseFirework();

                        // cooldown before next use
                        StartCoroutine(WeaponCooldownCo());
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Stops the weapons from being spammed like there is no tomorrow
        /// </summary>
        /// <returns></returns>
        private IEnumerator WeaponCooldownCo()
        {
            isCoR = true;
            yield return wait;
            isCoR = false;
        }


        /// <summary>
        /// Stops the toggle from being spammed
        /// </summary>
        /// <returns></returns>
        private IEnumerator ToggleCooldownCo()
        {
            canToggle = false;
            yield return new WaitForSeconds(.35f);
            canToggle = true;
        }


        /// <summary>
        /// Toggles the active weapon as needed
        /// </summary>
        private void ToggleActiveWeapon()
        {
            if (input.Gnome.ToggleWeaponOne.phase == InputActionPhase.Performed)
            {
                activeWeapon = GnomeWeapons.FishingRod;
            }

            if (input.Gnome.ToggleWeaponTwo.phase == InputActionPhase.Performed)
            {
                activeWeapon = GnomeWeapons.Umbrella;
            }

            if (input.Gnome.ToggleWeaponThree.phase == InputActionPhase.Performed)
            {
                activeWeapon = GnomeWeapons.Firework;
            }

            // update the weapon stats
            if (weaponUI)
            {
                weaponUI.SendUpdatedWeaponStats();
            }
        }

        /// <summary>
        /// Calls the fishing rod move
        /// </summary>
        private void UseFishingRod()
        {
            rodAttack.UseAbility();
        }

        /// <summary>
        /// Calls the umbrella move
        /// </summary>
        private void UseUmbrella()
        {
            umbrellaAttack.UseAbility();
        }

        /// <summary>
        /// Calls the firework move
        /// </summary>
        private void UseFirework()
        {
            fireworkAttack.UseAbility();
        }

        /// <summary>
        /// Gets the active weapon
        /// </summary>
        /// <returns>The active weapon</returns>
        public GnomeWeapons GetActiveWeapon()
        {
            return activeWeapon;
        }


        /// <summary>
        /// Sets the active weapon to what is inputted
        /// </summary>
        /// <param name="newWeapon">GnomeWeapon to change to. (0 = none, 1 = rod, 2 = um, 3 = fire)</param>
        public void SetGnomeWeapon(int newWeapon)
        {
            activeWeapon = (GnomeWeapons)newWeapon;
        }


        public void ToggleFishingRod()
        {
            if (rodAttack.rodAttackType.Equals(FishingRodAttack.Melee))
            {
                rodAttack.rodAttackType = FishingRodAttack.Ranged;
            }
            else
            {
                rodAttack.rodAttackType = FishingRodAttack.Melee;
            }

            weaponUI.ForceWeaponUIUpdate();
            StartCoroutine(ToggleCooldownCo());
        }
    }
}