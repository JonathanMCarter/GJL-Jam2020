using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DresslikeaGnome.OhGnomes
{
    public class BadgerTurretBehaviour : BaseEnemyBehaviour
    {
        [SerializeField] private float minDistantToShootTarget = 1.4f;
        [SerializeField] private float maxDistantToShootTarget = 5f;

        private GameObject shootTarget;
        private Animator turretAnimator;

        public GameObject bulletObject;

        // jonathan added this, makes the bullets better for performace sake.
        public List<GameObject> bulletPool;
        private int poolAmount = 5;


        private new void Awake()
        {
            base.Awake();
            shootTarget = base.getSunTarget();
            turretAnimator = GetComponent<Animator>();

            // jonathan added this, sets up the pool
            bulletPool = new List<GameObject>();

            for (int i = 0; i < poolAmount; i++)
            {
                GameObject _go = Instantiate(bulletObject);
                _go.name = "* (Pool) Badger Bullet *";
                _go.SetActive(false);
                bulletPool.Add(_go);
            }
        }


        private new void Update()
        {
            //make the turret looktoward the target
            transform.LookAt(shootTarget.transform);

            float shootTargetDistance = Vector3.Distance(transform.position, shootTarget.transform.position);

            if ((shootTargetDistance > minDistantToShootTarget) && (shootTargetDistance < maxDistantToShootTarget))
            {
                //the animation for firing then calls the function that makes the bullet
                turretAnimator.SetTrigger("FireTurret");
            }
        }

        public void FireBullet()
        {
            // replaced with object pooling, its better xD

            /* Old
            //create a new bullet
            Instantiate(bulletObject, transform.position, transform.rotation);
            */

            // New
            for (int i = 0; i < poolAmount; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    bulletPool[i].transform.position = transform.position;
                    bulletPool[i].transform.rotation = transform.rotation;
                    bulletPool[i].SetActive(true);
                    break;
                }
            }
        }
    }
}