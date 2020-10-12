using UnityEditor;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class GnomeMovement : MonoBehaviour
    {
        [Range(0, 400)]
        [SerializeField] private float moveSpeed;

        private bool canMove;

        private GameControls input;
        private Rigidbody rb;


        private void OnEnable()
        {
            // enables user input
            input.Enable();
        }

        private void OnDisable()
        {
            // disables user input
            input.Disable();
        }


        private void Awake()
        {
            input = new GameControls();
            rb = GetComponent<Rigidbody>();

            moveSpeed = 200f;
        }


        private void Update()
        {
            if (input.GnomeMovement.Movement.ReadValue<Vector2>().x != 0 || input.GnomeMovement.Movement.ReadValue<Vector2>().y != 0)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }


        private void FixedUpdate()
        {
            if (canMove)
            {
                Movement(input.GnomeMovement.Movement.ReadValue<Vector2>());
            }
        }


        private void Movement(Vector2 axis)
        {
            rb.velocity = new Vector3(axis.x, 0, axis.y).normalized * moveSpeed * Time.deltaTime;
        }
    }
}