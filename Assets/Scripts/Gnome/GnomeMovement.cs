using UnityEditor;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    /// <summary>
    /// Controls the Gnome movement, duh!
    /// </summary>
    public class GnomeMovement : MonoBehaviour
    {
        [Header("Gnome Speed")]
        [Tooltip("How fast should the gnome move?")]
        [Range(0, 600)]
        [SerializeField] private float moveSpeed = 200f;    // defines the move speed
        [SerializeField] private float moveDelay = .1f;

        private bool canMove;                               // can the gnome move, keeps the physics movement in fixed update while having the controls be responsive in normal update

        private GameControls input;                         // ref to the input system
        private Rigidbody rb;                               // ref to the rb attached to the gnome
        private Animator anim;

        internal bool freezeGnome;


        private void OnEnable()
        {
            input.Enable();                                 // enables user input
        }

        private void OnDisable()
        {
            input.Disable();                                // disables user input
        }


        private void Awake()
        {
            input = new GameControls();                     // setup ref to input system
            rb = GetComponentInChildren<Rigidbody>();                 // setup ref to rigidbody
            anim = GetComponentsInChildren<Animator>()[1];
        }


        private void Update()
        {
            if (!freezeGnome)
            {
                // if the input is pressed, either x or y axis
                if (!input.Gnome.Movement.ReadValue<Vector2>().x.Equals(0) || !input.Gnome.Movement.ReadValue<Vector2>().y.Equals(0))
                {
                    // player can move
                    anim.SetBool("IsMoving", true);
                    canMove = true;
                }
                else
                {
                    // otherwise player can't move :(
                    anim.SetBool("IsMoving", false);
                    canMove = false;
                }
            }
        }


        private void FixedUpdate()
        {
            if (!freezeGnome)
            {
                // if the gnome can move, move it
                if (canMove)
                {
                    Movement(input.Gnome.Movement.ReadValue<Vector2>());
                }
            }
        }




        /// <summary>
        /// Sets the rigidbody verlocity to the movement input
        /// </summary>
        /// <param name="axis">The input vector2 from the input system</param>
        private void Movement(Vector2 axis)
        {
            // movement
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(axis.x, 0, axis.y).normalized * moveSpeed * Time.deltaTime, moveDelay);

            // look rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(axis.x, 0, axis.y)).normalized, .2f);
        }
    }
}