using DresslikeaGnome.OhGnomes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyBehaviour : BaseEnemyBehaviour
{
    public GameObject attackCollider;

    // Update is called once per frame
    protected override void Update(){
        //just using the basic update method from the parent
        base.Update();
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

