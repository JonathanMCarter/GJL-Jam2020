using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DresslikeaGnome.OhGnomes
{

    public class IntroCutsceneScript : MonoBehaviour
    {

        [SerializeField] private GameObject[] introImage;
        
        [SerializeField] private GameObject sceneTransitionController;
        private int introImageNo = 0;
        private int introImageCount;

        private GameControls input;
        // Start is called before the first frame update
        void Start()
        {
            introImageCount = introImage.Length;

            Time.timeScale = 0;
        }


        private void Awake()
        {
            input = new GameControls();
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void ChangeImage()
        {
            introImage[introImageNo].SetActive(false);

            introImageNo++;

            if(introImageNo < introImageCount)
            {
                introImage[introImageNo].SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                sceneTransitionController.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }

}
