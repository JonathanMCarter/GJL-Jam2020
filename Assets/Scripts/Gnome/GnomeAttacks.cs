using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public enum GnomeWeapons { None, FishingRod, Umbrella, Firework };

    [RequireComponent(typeof(FishingRodMove), typeof(UmbrellaMove))]
    public class GnomeAttacks : MonoBehaviour
    {
        [SerializeField] private GnomeWeapons activeWeapon;

        private float coolDown;
        private bool isCoR;

        private GameControls input;
        private FishingRodMove rodAttack;
        private UmbrellaMove umbrellaAttack;
        private FireworkMove fireworkAttack;

        private WaitForSeconds wait;

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
            anim = GetComponent<Animator>();
            wait = new WaitForSeconds(coolDown);
        }

        private void Start()
        {
            rodAttack = GetComponent<FishingRodMove>();
            umbrellaAttack = GetComponent<UmbrellaMove>();
            fireworkAttack = GetComponent<FireworkMove>();
        }

        private void Update()
        {
            ToggleActiveWeapon();

            input.Gnome.Attack.performed += ctx => UseActiveWeapon();
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


        public GnomeWeapons GetActiveWeapon()
        {
            return activeWeapon;
        }
    }
}