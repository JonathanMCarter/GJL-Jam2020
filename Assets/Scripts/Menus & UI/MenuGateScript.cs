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

        [SerializeField] private Animator anim;


        private void OnTriggerEnter(Collider other)
        {
            anim.SetTrigger("OpenDoor");

            if (other.gameObject.CompareTag("Player"))
            {
                if (shouldChangeScene)
                {
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else if (shouldQuitGame)
                {
                    Application.Quit();
                }
                else
                {
                    UI.SetActive(true);
                }
            }
        }


        private void OnTriggerExit(Collider other)
        {
            anim.SetTrigger("CloseDoor");
        }
    }
}