using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBulletBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletRigidBody;

    public float bulletSpeed = 5f;

    private void Start() 
    {
        try
        {
            if(bulletRigidBody == null)
            {
                bulletRigidBody = gameObject.GetComponent<Rigidbody>();
            }

            bulletRigidBody.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);

        }
        catch (System.Exception)
        {
            Debug.Log("The bullet needs a rigidbody!");   
            throw;
        }
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }

}
