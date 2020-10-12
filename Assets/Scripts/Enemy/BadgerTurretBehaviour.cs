using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerTurretBehaviour : BaseEnemyBehaviour
{
    [SerializeField] private float minDistantToShootTarget = 1.4f;
    [SerializeField] private float maxDistantToShootTarget = 5f;

    private GameObject shootTarget;
    private Animator animator;


    private void Awake() 
    {
        base.Awake();
        shootTarget = base.getSunTarget();
        animator = GetComponent<Animator>();

    }
    private void Update() 
    {
        transform.LookAt(shootTarget.transform);

        float shootTargetDistance = Vector3.Distance(transform.position, shootTarget.transform.position);

        if((shootTargetDistance > minDistantToShootTarget) && (shootTargetDistance < maxDistantToShootTarget))
        {
            animator.SetTrigger("FireTurret");
        }
    }

    public void FireBullet()
    {
        Debug.Log("Firing Bullet");
    }
}
