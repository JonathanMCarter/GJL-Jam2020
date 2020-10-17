using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DresslikeaGnome.OhGnomes
{
    public class BadgerEnemyBehaviour : BaseEnemyBehaviour
    {
        public GameObject attackCollider;

        // Update is called once per frame
        protected override void Awake()
        {
            base.Awake();
        }

        public void ActivateAttack()
        {
            attackCollider.GetComponent<BoxCollider>().enabled = true;
        }

        public void DeactivateAttack()
        {
            attackCollider.GetComponent<BoxCollider>().enabled = false;
        }
    }
}