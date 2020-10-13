using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerEnemyBehaviour : BaseEnemyBehaviour
{
    public GameObject attackCollider;

    // Update is called once per frame
    protected override void Awake() {
        base.Awake();
    }

    public void activateAttack()
    {
        attackCollider.GetComponent<Collider>().enabled = true;
    }

    public void deactivateAttack()
    {
        attackCollider.GetComponent<Collider>().enabled = false;
    }
}
