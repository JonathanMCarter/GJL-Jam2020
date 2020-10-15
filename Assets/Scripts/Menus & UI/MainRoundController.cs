using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DresslikeaGnome.OhGnomes
{
    public class MainRoundController : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private List<GameObject> roundControllerObjects;

        private int currentRound = 0;

        void Start()
        {
            StartRound();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void StartRound()
        {
            Debug.Log("Starting the Round");

            roundControllerObjects[currentRound].SetActive(true);
        }

        public void EndRound()
        {
            Debug.Log("Ending Round");

            roundControllerObjects[currentRound].SetActive(false);

            currentRound++;

            if (currentRound > roundControllerObjects.Count)
                EndGame();  //all rounds completed
        }

        public void StartNextRound()
        {
            StartRound();   //onto the next round!
        }

        private void EndGame()
        {
            Debug.Log("Game Complete!");
        }
    }
}