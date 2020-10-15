using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DresslikeaGnome.OhGnomes
{
    public class TESTPlayerHealthDisplay : MonoBehaviour
    {

        public int playerHealth = 3;

        public Text healthText;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            healthText.text = playerHealth.ToString();
        }

        void removeHealth()
        {
            //if the player has health then just remove it
            if (playerHealth >= 1)
                playerHealth--;
            else
                Destroy(gameObject);
            //otherwise deaded

        }

        private void OnTriggerEnter(Collider other)
        {
            //when the colider of the enemy attack enters then do this
            if (other.gameObject.tag == "EnemyAttack")
            {
                removeHealth();
            }
        }
    }
}