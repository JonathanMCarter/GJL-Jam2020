using DresslikeaGnome.OhGnomes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DresslikeaGnome.OhGnomes
{
    public class RatEnemyBehaviour : BaseEnemyBehaviour
    {
        public GameObject attackCollider;

        // Update is called once per frame
        protected override void Update()
        {
            //just using the basic update method from the parent
            base.Update();
        }

        public void ActivateAttack()
        {
            attackCollider.GetComponent<Collider>().enabled = true;
        }

        public void DeactivateAttack()
        {
            attackCollider.GetComponent<Collider>().enabled = false;
        }
    }
}