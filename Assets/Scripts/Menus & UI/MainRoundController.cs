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
        
        [SerializeField]
        private GameObject nextRoundUI;
        private int currentRound = 0;

        private SceneTransitions trans;


        void Start()
        {
            trans = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitions>();

            StartRound();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void StartRound()
        {
            roundControllerObjects[currentRound].SetActive(true);
        }

        public void EndRound()
        {
            roundControllerObjects[currentRound].SetActive(false);

            currentRound++;

            //because of how arrays are counts (item 1 = array spot 0) have to look one below
            if(currentRound >= roundControllerObjects.Count)
                EndGame();  //all rounds completed

            //still another round to go!
            nextRoundUI.SetActive(true);

        }

        public void StartNextRound()
        {
            nextRoundUI.SetActive(false);

            StartRound();   //onto the next round!
        }

        private void EndGame()
        {
            trans.ChangeSceneTransition("Main Menu");
        }
    }

}

