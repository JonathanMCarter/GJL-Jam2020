using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DresslikeaGnome.OhGnomes
{
    public class BaseEnemyBulletBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody bulletRigidBody;

        public float bulletSpeed = 5f;

        internal Transform _target;


        private void Start()
        {
            try
            {
                if (bulletRigidBody == null)
                {
                    bulletRigidBody = gameObject.GetComponent<Rigidbody>();
                }

                bulletRigidBody.velocity = (_target.transform.position - transform.position).normalized * bulletSpeed;

            }
            catch (System.Exception)
            {
                Debug.Log("The bullet needs a rigidbody!");
                throw;
            }
        }

        // jonathan edited this, so it doesn't destory, instead disables.
        private void OnCollisionEnter(Collision other)
        {
            gameObject.SetActive(false);
        }

        // jonathan added this, so the bullets actually disapear once they have hit something... (I use triggers)
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SunTarget"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}