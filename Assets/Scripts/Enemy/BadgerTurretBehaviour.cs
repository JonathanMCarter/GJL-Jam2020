using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerTurretBehaviour : BaseEnemyBehaviour
{
    [SerializeField] private float minDistantToShootTarget = 1.4f;
    [SerializeField] private float maxDistantToShootTarget = 5f;

    private GameObject shootTarget;
    private Animator turretAnimator;

    public GameObject bulletObject;


    private void Awake() 
    {
        base.Awake();
        shootTarget = base.getSunTarget();
        turretAnimator = GetComponent<Animator>();

    }
    private void Update() 
    {
        //make the turret looktoward the target
        transform.LookAt(shootTarget.transform);

        float shootTargetDistance = Vector3.Distance(transform.position, shootTarget.transform.position);

        if((shootTargetDistance > minDistantToShootTarget) && (shootTargetDistance < maxDistantToShootTarget))
        {
            //the animation for firing then calls the function that makes the bullet
            turretAnimator.SetTrigger("FireTurret");
        }
    }

    public void FireBullet()
    {
        //create a new bullet
        Instantiate(bulletObject, transform.position, transform.rotation);
    }
}
