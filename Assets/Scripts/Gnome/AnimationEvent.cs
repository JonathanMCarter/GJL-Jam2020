using CarterGames.Assets.AudioManager;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class AnimationEvent : MonoBehaviour
    {
        private FishingRodMove rodMove;
        [SerializeField] private BoxCollider attackCollider;
        [SerializeField] private BadgerTurretBehaviour turret;
        //private AudioManager am;


        private void Start()
        {
            rodMove = GetComponentInParent<FishingRodMove>();
            //am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }


        public void SpawnProjectile()
        {
            rodMove.fishingRodProjectile.transform.position = rodMove.fishingRodObject.transform.GetChild(0).transform.position;
            rodMove.fishingRodProjectile.transform.rotation = rodMove.fishingRodObject.transform.GetChild(0).transform.rotation;
            rodMove.fishingRodProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
            rodMove.fishingRodProjectile.GetComponent<Rigidbody>().velocity = transform.forward * 12.5f;
            rodMove.fishingRodProjectile.SetActive(true);
            rodMove.fishingRodObject.transform.GetChild(0).GetComponent<LineRenderer>().enabled = true;
            rodMove.moves.freezeGnome = true;
            rodMove.hasSwung = true;
        }


        //public void PlayFootstep()
        //{
        //    am.Play("");
        //}


        public void ActivateAttack()
        {
            attackCollider.GetComponent<Collider>().enabled = true;
        }

        public void DeactivateAttack()
        {
            attackCollider.GetComponent<Collider>().enabled = false;
        }


        public void FireBullet()
        {
            turret.FireBullet();
        }
    }
}