using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class MenuGateScript : MonoBehaviour
    {
        [SerializeField] private bool shouldChangeScene;
        [SerializeField] private bool shouldQuitGame;
        [SerializeField] private string sceneName;
        [SerializeField] private GameObject UI;
        private SceneTransitions trans;

        private void Start()
        {
            trans = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitions>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // opens a scene
                if (shouldChangeScene)
                {
                    trans.ChangeSceneTransition(sceneName);
                }
                else if (shouldQuitGame)    // quits the game if true on the portal
                {
                    Application.Quit();
                }
                else    // opens a ui element if set
                {
                    UI.SetActive(true);
                }
            }
        }
    }
}