using DresslikeaGnome.OhGnomes.GamePad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DresslikeaGnome.OhGnomes
{

    public class IntroCutsceneScript : MonoBehaviour
    {

        [SerializeField] private GameObject[] introImage;
        [SerializeField] private MainRoundController mainRound;
        [SerializeField] private GamePadButtonPress button;

        private int introImageNo = 0;
        private int introImageCount;

        private GameControls input;

        private void OnEnable()
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }


        // Start is called before the first frame update
        void Start()
        {
            introImageCount = introImage.Length;

            Time.timeScale = 0;
        }


        private void Awake()
        {
            input = new GameControls();
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (input.Menu.MenuUse.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            {
                ChangeImage();
            }
        }


        public void ChangeImage()
        {
            if (!(introImageNo).Equals(introImageCount))
            {
                introImage[introImageNo].SetActive(false);

                introImageNo++;

                if (introImageNo < introImageCount)
                {
                    introImage[introImageNo].SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    mainRound.isTimerRunning = true;
                    StartCoroutine(CanPressButton());
                    GetComponent<CanvasGroup>().alpha = 0;
                    GetComponent<CanvasGroup>().interactable = false;
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }
        }


        private IEnumerator CanPressButton()
        {
            yield return new WaitForSeconds(.5f);
            button.canPress = true;
        }
    }
}
