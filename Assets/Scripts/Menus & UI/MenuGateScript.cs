using UnityEngine;
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
        [SerializeField] private string sceneName;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (shouldChangeScene)
                {
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {

                }
            }
        }
    }
}