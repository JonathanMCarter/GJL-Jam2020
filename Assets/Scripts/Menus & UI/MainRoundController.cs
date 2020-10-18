using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace DresslikeaGnome.OhGnomes
{
    public class MainRoundController : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private List<GameObject> roundControllerObjects;
        
        [SerializeField]
        private GameObject nextRoundUI;
        [SerializeField] private int currentRound = 0;

        // jonathan edit
        [Header("Timer Text & Game UI")]
        [SerializeField] private GameObject[] _GameUI;
        [SerializeField] private Text _timerText;
        [SerializeField] private float _timeLimit;
        [SerializeField] private float _timer;
        [SerializeField] internal bool isTimerRunning;
        [SerializeField] private string _mins, _secs;

        private SceneTransitions trans;


        void Start()
        {
            trans = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitions>();


            // jonathan edit
            for (int i = 0; i < _GameUI.Length; i++)
            {
                _GameUI[i].SetActive(false);
            }

            _timer = _timeLimit;
        }

        // Update is called once per frame
        void Update()
        {
            // jonathan edit - round start timer...
            if (isTimerRunning)
            {
                _timer -= Time.deltaTime;

                if (_timer < 0)
                {
                    StartNextRound();
                    _timer = 90;
                    isTimerRunning = false;
                }
            }

            TimerDisplay();
        }


        private void StartRound()
        {
            roundControllerObjects[currentRound].SetActive(true);
        }


        public void EndRound()
        {
            roundControllerObjects[currentRound].GetComponent<BaseRoundController>().ClearObjectPool();
            roundControllerObjects[currentRound].SetActive(false);

            currentRound++;

            //because of how arrays are counts (item 1 = array spot 0) have to look one below
            if(currentRound >= roundControllerObjects.Count)
                EndGame();  //all rounds completed

            //still another round to go!
            nextRoundUI.SetActive(true);

            // jonathan edit
            for (int i = 0; i < _GameUI.Length; i++)
            {
                _GameUI[i].SetActive(false);
            }

            isTimerRunning = true;
            _timer = _timeLimit;
        }


        public void StartNextRound()
        {
            nextRoundUI.SetActive(false);

            // jonathan edit
            for (int i = 0; i < _GameUI.Length; i++)
            {
                _GameUI[i].SetActive(true);
            }

            isTimerRunning = false;

            StartRound();   //onto the next round!
        }

        private void EndGame()
        {
            trans.ChangeSceneTransition("Win Scene");
        }


        /// <summary>
        /// Shows the round timer
        /// </summary>
        private void TimerDisplay()
        {
            if (isTimerRunning)
            {
                _mins = Mathf.Floor(((_timer) % 3600) / 60).ToString("00");
                _secs = Mathf.Floor((_timer) % 60).ToString("00");
                _timerText.text = "Next Round In: " + _mins + ":" + _secs;
            }
        }
    }
}

